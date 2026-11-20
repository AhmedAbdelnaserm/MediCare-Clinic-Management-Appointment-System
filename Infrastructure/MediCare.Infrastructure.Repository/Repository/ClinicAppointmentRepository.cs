using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class ClinicAppointmentRepository : IClinicAppointmentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClinicAppointmentRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public Task<List<Appointment>> GetClinicAppointmentsAsync(int clinicId) =>
        _dbContext.Appointments.AsNoTracking()
            .Where(appointment => appointment.Slot.ClinicDoctor.ClinicId == clinicId &&
                appointment.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
            .Include(appointment => appointment.Patient).ThenInclude(patient => patient.User)
            .Include(appointment => appointment.Slot).ThenInclude(slot => slot.ClinicDoctor)
                .ThenInclude(clinicDoctor => clinicDoctor.Doctor)
            .Include(appointment => appointment.Slot).ThenInclude(slot => slot.ClinicDoctor)
                .ThenInclude(clinicDoctor => clinicDoctor.Clinic)
            .OrderByDescending(appointment => appointment.StartAt)
            .Take(200)
            .ToListAsync();

    public async Task<bool> TryCancelAsync(int appointmentId, int clinicId, string userId, string? reason)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var now = DateTime.UtcNow;
        var appointment = await _dbContext.Appointments.AsNoTracking()
            .FirstOrDefaultAsync(item => item.AppointmentId == appointmentId &&
                item.Slot.ClinicDoctor.ClinicId == clinicId &&
                item.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                item.StartAt > now && item.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
        if (appointment is null)
            return false;

        var changed = await _dbContext.Appointments
            .Where(item => item.AppointmentId == appointmentId &&
                item.Slot.ClinicDoctor.ClinicId == clinicId &&
                item.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed && item.StartAt > now)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(item => item.AppointmentStatusId, (int)AppointmentStatusEnum.Cancelled)
                .SetProperty(item => item.CancelledAtUtc, now)
                .SetProperty(item => item.CancellationReason, reason)
                .SetProperty(item => item.LastModificationTime, now)
                .SetProperty(item => item.LastModifierUserId, userId));
        if (changed != 1)
            return false;

        await _dbContext.Slots.Where(slot => slot.SlotId == appointment.SlotId)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(slot => slot.IsAvailable, true)
                .SetProperty(slot => slot.LastModificationTime, now)
                .SetProperty(slot => slot.LastModifierUserId, userId));

        await transaction.CommitAsync();
        return true;
    }
}
