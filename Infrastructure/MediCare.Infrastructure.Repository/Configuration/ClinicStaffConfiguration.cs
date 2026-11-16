
using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCare.Infrastructure.Repository.Configuration;

public class ClinicStaffConfiguration
    : IEntityTypeConfiguration<ClinicStaff>
{
    public void Configure(EntityTypeBuilder<ClinicStaff> builder)
    {
        builder.HasKey(x => x.ClinicStaffId);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder.HasOne(x => x.User)
            .WithOne(x => x.ClinicStaff)
            .HasForeignKey<ClinicStaff>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Clinic)
            .WithMany(x => x.ClinicStaffs)
            .HasForeignKey(x => x.ClinicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ClinicId);
    }
}
