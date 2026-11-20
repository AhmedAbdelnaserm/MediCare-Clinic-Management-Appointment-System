using MediCare.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediCare.Infrastructure.Repository.Configuration;

public sealed class SlotConfiguration : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder.HasKey(slot => slot.SlotId);
        builder.HasIndex(slot => new { slot.ClinicDoctorId, slot.SlotDateTime }).IsUnique();
    }
}
