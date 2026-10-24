using AutoMapper;
using MediCare.Application.Identity.Base;
using MediCare.Application.Identity.Dto.Authentication;
using MediCare.Application.Identity.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Common.Helper;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.Identity.IAppService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediCare.Application.Identity.AppService
{
    public class AuthService : BaseAppService, IAuthService
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly JWT Jwt;
        public AuthService(IMapper mapper, ILocalizationService localization, ILogger<AuthService> logger,
            IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IOptions<JWT> jwt)
            : base(mapper, localization, logger, unitOfWork)
        {
            UserManager = userManager;
            Jwt = jwt.Value;
        }

        public async Task<ResponseDto<AuthModel>> UserLogin(LoginDto request)
        {
            ResponseDto<AuthModel> response = await ValidateLoginRequest(request);
            if (response.Code != 0)
                return response;

            var user = await UserManager.FindByEmailAsync(request.Email);
            if (user == null)
                return response;
            var jwtGenerateToken = await GenerateToken(user);
            var authModel = new AuthModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtGenerateToken),
                Roles = (await UserManager.GetRolesAsync(user)).ToList(),
                TokenExpireOn = jwtGenerateToken.ValidTo
            };
            return response.GetSuccessResponse(authModel, Localization.LoginSuccessfully);
        }
        public async Task<ResponseDto<AuthModel>> UserRegister(RegisterDto request)
        {
            var user = new ApplicationUser();
            ResponseDto<AuthModel> response = await ValidateRegisterRequest(request);
            if (response.Code != 0)
                return response;
            try
            {
                // Create User
                user = Mapper.Map<ApplicationUser>(request);
                var result = await UserManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Empty;
                    foreach (var err in result.Errors)
                    {
                        errors += $"{err.Description},";
                    }
                    response.SetErrorResponse(errors.TrimEnd(','));
                    return response;
                }

                // Assign Role
                var roleResult = await UserManager.AddToRoleAsync(user, nameof(UserRolesEnum.Patient));

                if (!roleResult.Succeeded)
                {
                    var errors = string.Empty;
                    foreach (var err in result.Errors)
                    {
                        errors += $"{err.Description},";
                    }
                    // Rollback: delete the user if role assignment failed
                    await UserManager.DeleteAsync(user);
                    response.SetErrorResponse(errors.TrimEnd(','));
                    return response;
                }

                // Generate Token
                var jwtGenerateToken = await GenerateToken(user);

                var authModel = Mapper.Map<AuthModel>(user);
                authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtGenerateToken);
                authModel.Roles = (await UserManager.GetRolesAsync(user)).ToList();
                authModel.TokenExpireOn = jwtGenerateToken.ValidTo;

                return response.GetSuccessResponse(authModel, Localization.RegisterSuccessfully);
            }
            catch (Exception)
            {
                // Catch any unexpected error → delete user if already created
                if (user != null)
                {
                    var existingUser = await UserManager.FindByIdAsync(user.Id);
                    if (existingUser != null)
                        await UserManager.DeleteAsync(existingUser);
                }
                return response;
            }
        }
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await UserManager.GetClaimsAsync(user);
            var userRoles = await UserManager.GetRolesAsync(user);

            var roleclaims = new List<Claim>();
            foreach (var role in userRoles)
                roleclaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleclaims);

            var symmetricSycyrityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSycyrityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
                (
                    issuer: Jwt.Issuer,
                    audience: Jwt.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(Jwt.ExpiryInMinutes),
                    signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }
        private async Task<ResponseDto<AuthModel>> ValidateRegisterRequest(RegisterDto request)
        {
            ResponseDto<AuthModel> response = new
                ResponseDto<AuthModel>().GetSuccessResponse();
            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);
            if (request.UserName == null || request.Email == null ||
                request.Password == null)
                return response.GetErrorResponse(Localization.DataRequired);
            if (await UserManager.FindByEmailAsync(request.Email) != null ||
                await UserManager.FindByNameAsync(request.UserName) != null)
                return response.GetErrorResponse(Localization.EmailOrUserNameAlreadyExist);

            return response;
        }
        private async Task<ResponseDto<AuthModel>> ValidateLoginRequest(LoginDto request)
        {
            ResponseDto<AuthModel> response = new
                ResponseDto<AuthModel>().GetSuccessResponse();
            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);
            if (request.Password == null || request.Email == null)
                return response.GetErrorResponse(Localization.DataRequired);
            var user = await UserManager.FindByEmailAsync(request.Email);
            if (user == null || !await UserManager.CheckPasswordAsync(user, request.Password))
                return response.GetErrorResponse(Localization.EmailOrPasswordIsIncorrect);

            return response;
        }
    }
}
