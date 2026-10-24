namespace MediCare.Application.Identity.Dto.Authentication
{
    public class AuthModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public DateTime TokenExpireOn { get; set; }
    }
}
