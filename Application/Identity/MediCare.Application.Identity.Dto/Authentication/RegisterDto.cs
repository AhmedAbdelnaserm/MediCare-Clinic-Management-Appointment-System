using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.Identity.Dto.Authentication
{
    public class RegisterDto
    {
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public int UserRoles { get; set; }
    }
}
