using AutoMapper;
using MediCare.Application.Identity.Dto.Authentication;
using MediCare.Core.Entity.Entity;

namespace MediCare.Application.Identity.Mapping
{
    public class ApplicationUserMapping :Profile
    {
        public ApplicationUserMapping()
        {
            CreateMap<RegisterDto, ApplicationUser>()
                .ForMember(destination => destination.Email,
                    options => options.MapFrom(source => source.Email.Trim()))
                .ForMember(destination => destination.UserName,
                    options => options.MapFrom(source => source.UserName.Trim()));

            CreateMap<ApplicationUser, AuthModel>()
                .ForMember(destination => destination.UserId,
                    options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.UserName,
                    options => options.MapFrom(source => source.UserName ?? string.Empty))
                .ForMember(destination => destination.Email,
                    options => options.MapFrom(source => source.Email ?? string.Empty))
                .ForMember(destination => destination.Token, options => options.Ignore())
                .ForMember(destination => destination.Roles, options => options.Ignore())
                .ForMember(destination => destination.TokenExpireOn, options => options.Ignore());
        }
    }
}
