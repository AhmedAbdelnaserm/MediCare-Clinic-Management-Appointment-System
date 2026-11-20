using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCare.Infrastructure.Repository.Configuration;

public sealed class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.HasKey(item => item.UserNotificationId);
        builder.Property(item => item.UserId).HasMaxLength(450).IsRequired();
        builder.Property(item => item.Type).HasMaxLength(40).IsRequired();
        builder.Property(item => item.Title).HasMaxLength(150).IsRequired();
        builder.Property(item => item.Message).HasMaxLength(500).IsRequired();
        builder.Property(item => item.DeduplicationKey).HasMaxLength(600);
        builder.HasIndex(item => item.DeduplicationKey).IsUnique().HasFilter("[DeduplicationKey] IS NOT NULL");
        builder.HasIndex(item => new { item.UserId, item.CreatedAtUtc });
        builder.HasIndex(item => new { item.RelatedAppointmentId, item.Type });
    }
}
