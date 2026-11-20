using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCare.Infrastructure.Repository.Configuration;

public sealed class ScheduleExceptionConfiguration : IEntityTypeConfiguration<ScheduleException>
{
    public void Configure(EntityTypeBuilder<ScheduleException> builder)
    {
        builder.HasKey(item => item.ScheduleExceptionId);
        builder.Property(item => item.Reason).HasMaxLength(250);
        builder.HasIndex(item => new { item.ClinicDoctorId, item.ExceptionDate }).IsUnique();
        builder.HasOne(item => item.ClinicDoctor).WithMany(link => link.ScheduleExceptions)
            .HasForeignKey(item => item.ClinicDoctorId).OnDelete(DeleteBehavior.Restrict);
        builder.ToTable(table => table.HasCheckConstraint("CK_ScheduleException_ValidHours",
            "([IsClosed] = 1 AND [StartTime] IS NULL AND [EndTime] IS NULL) OR " +
            "([IsClosed] = 0 AND [StartTime] IS NOT NULL AND [EndTime] IS NOT NULL AND [StartTime] < [EndTime])"));
    }
}
