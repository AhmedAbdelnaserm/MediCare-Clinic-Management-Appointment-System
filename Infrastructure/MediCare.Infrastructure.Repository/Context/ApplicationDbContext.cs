using MediCare.Core.Entity.Entity;
using MediCare.Infrastructure.Repository.Configuration;
using MediCare.Infrastructure.Repository.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Context
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ClinicStaffConfiguration).Assembly
            );

            DataSeeding.Seed(modelBuilder);
        }

    }
}
