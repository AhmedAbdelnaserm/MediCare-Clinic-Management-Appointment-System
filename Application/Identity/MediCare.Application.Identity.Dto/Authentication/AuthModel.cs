namespace MediCare.Application.Identity.Dto.Authentication
{
    public class AuthModel
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
        public DateTime TokenExpireOn { get; set; }
    }
}
