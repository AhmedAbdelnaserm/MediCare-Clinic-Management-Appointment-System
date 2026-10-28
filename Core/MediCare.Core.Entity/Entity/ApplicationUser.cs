using Microsoft.AspNetCore.Identity;

namespace MediCare.Core.Entity.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string? ContactNumber { get; set; }
    }
}
