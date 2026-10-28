using Microsoft.AspNetCore.Identity;

namespace MediCare.Core.Entity.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
