using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AppointmentRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public Task<List<Slot>> GetAvailableSlotsAsync(int? doctorId)
    {
        var now = DateTime.UtcNow;
        var horizon = now.AddDays(60);
        return _dbContext.Slots
            .AsNoTracking()
            .Where(slot => slot.IsAvailable &&
                           slot.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                           slot.SlotDateTime > now &&
                           slot.SlotDateTime <= horizon &&
                           slot.ClinicDoctor.IsActive &&
                           slot.ClinicDoctor.ConsultationDurationMinutes > 0 &&
                           slot.ClinicDoctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                           slot.ClinicDoctor.Clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                           slot.ClinicDoctor.Doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                           (doctorId == null || slot.ClinicDoctor.DoctorId == doctorId))
            .Include(slot => slot.ClinicDoctor)
                .ThenInclude(clinicDoctor => clinicDoctor.Doctor)
            .Include(slot => slot.ClinicDoctor)
                .ThenInclude(clinicDoctor => clinicDoctor.Clinic)
            .OrderBy(slot => slot.SlotDateTime)
            .Take(500)
            .ToListAsync();
    }

    public Task<List<Appointment>> GetPatientAppointmentsAsync(int patientId) =>
        _dbContext.Appointments
            .AsNoTracking()
            .Where(appointment => appointment.PatientId == patientId &&
                                  appointment.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
            .Include(appointment => appointment.Slot)
                .ThenInclude(slot => slot.ClinicDoctor)
                    .ThenInclude(clinicDoctor => clinicDoctor.Doctor)
            .Include(appointment => appointment.Slot)
                .ThenInclude(slot => slot.ClinicDoctor)
                    .ThenInclude(clinicDoctor => clinicDoctor.Clinic)
            .OrderByDescending(appointment => appointment.StartAt)
            .ToListAsync();

    public async Task<Appointment?> TryBookSlotAsync(int slotId, int patientId, string bookedByUserId)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var now = DateTime.UtcNow;

        var slot = await _dbContext.Slots
            .AsNoTracking()
            .Include(candidate => candidate.ClinicDoctor)
            .FirstOrDefaultAsync(candidate => candidate.SlotId == slotId &&
                candidate.IsAvailable && candidate.SlotDateTime > now &&
                candidate.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                candidate.ClinicDoctor.IsActive &&
                candidate.ClinicDoctor.ConsultationDurationMinutes > 0 &&
                candidate.ClinicDoctor.Clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                candidate.ClinicDoctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

        if (slot is null)
            return null;

        var reserved = await _dbContext.Slots
            .Where(candidate => candidate.SlotId == slotId && candidate.IsAvailable &&
                candidate.SlotDateTime > now &&
                candidate.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                candidate.ClinicDoctor.IsActive &&
                candidate.ClinicDoctor.ConsultationDurationMinutes > 0 &&
                candidate.ClinicDoctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                candidate.ClinicDoctor.Clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(candidate => candidate.IsAvailable, false)
                .SetProperty(candidate => candidate.LastModificationTime, now)
                .SetProperty(candidate => candidate.LastModifierUserId, bookedByUserId));

        if (reserved != 1)
            return null;

        var appointment = new Appointment
        {
            PatientId = patientId,
            SlotId = slotId,
            BookedByUserId = bookedByUserId,
            StartAt = slot.SlotDateTime,
            EndAt = slot.SlotDateTime.AddMinutes(slot.ClinicDoctor.ConsultationDurationMinutes),
            AppointmentStatusId = (int)AppointmentStatusEnum.Confirmed,
            CreationTime = now,
            CreatorUserId = bookedByUserId
        };

        await _dbContext.Appointments.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();
        appointment = await _dbContext.Appointments
            .AsNoTracking()
            .Include(item => item.Slot)
                .ThenInclude(item => item.ClinicDoctor)
                    .ThenInclude(item => item.Doctor)
            .Include(item => item.Slot)
                .ThenInclude(item => item.ClinicDoctor)
                    .ThenInclude(item => item.Clinic)
            .SingleAsync(item => item.AppointmentId == appointment.AppointmentId);
        await transaction.CommitAsync();
        return appointment;
    }

    public async Task<bool> TryCancelAsync(int appointmentId, int patientId, string userId, string? reason)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var now = DateTime.UtcNow;

        var appointment = await _dbContext.Appointments
            .AsNoTracking()
            .FirstOrDefaultAsync(candidate => candidate.AppointmentId == appointmentId &&
                candidate.PatientId == patientId &&
                candidate.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                candidate.StartAt > now &&
                candidate.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

        if (appointment is null)
            return false;

        var cancelled = await _dbContext.Appointments
            .Where(candidate => candidate.AppointmentId == appointmentId &&
                candidate.PatientId == patientId &&
                candidate.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                candidate.StartAt > now)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(candidate => candidate.AppointmentStatusId, (int)AppointmentStatusEnum.Cancelled)
                .SetProperty(candidate => candidate.CancelledAtUtc, now)
                .SetProperty(candidate => candidate.CancellationReason, reason)
                .SetProperty(candidate => candidate.LastModificationTime, now)
                .SetProperty(candidate => candidate.LastModifierUserId, userId));

        if (cancelled != 1)
            return false;

        await _dbContext.Slots
            .Where(slot => slot.SlotId == appointment.SlotId)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(slot => slot.IsAvailable, true)
                .SetProperty(slot => slot.LastModificationTime, now)
                .SetProperty(slot => slot.LastModifierUserId, userId));

        await transaction.CommitAsync();
        return true;
    }

    public async Task<bool> TryRescheduleAsync(int appointmentId, int newSlotId, int patientId, string userId)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var now = DateTime.UtcNow;
        var appointment = await _dbContext.Appointments.AsNoTracking()
            .FirstOrDefaultAsync(item => item.AppointmentId == appointmentId &&
                item.PatientId == patientId &&
                item.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                item.StartAt > now &&
                item.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
        if (appointment is null || appointment.SlotId == newSlotId)
            return false;

        var newSlot = await _dbContext.Slots.AsNoTracking()
            .Include(slot => slot.ClinicDoctor)
            .FirstOrDefaultAsync(slot => slot.SlotId == newSlotId && slot.IsAvailable &&
                slot.SlotDateTime > now &&
                slot.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                slot.ClinicDoctor.IsActive &&
                slot.ClinicDoctor.ConsultationDurationMinutes > 0 &&
                slot.ClinicDoctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                slot.ClinicDoctor.Clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
        if (newSlot is null)
            return false;

        var reserved = await _dbContext.Slots
            .Where(slot => slot.SlotId == newSlotId && slot.IsAvailable &&
                slot.SlotDateTime > now &&
                slot.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                slot.ClinicDoctor.IsActive &&
                slot.ClinicDoctor.ConsultationDurationMinutes > 0 &&
                slot.ClinicDoctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                slot.ClinicDoctor.Clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(slot => slot.IsAvailable, false)
                .SetProperty(slot => slot.LastModificationTime, now)
                .SetProperty(slot => slot.LastModifierUserId, userId));
        if (reserved != 1)
            return false;

        var updated = await _dbContext.Appointments
            .Where(item => item.AppointmentId == appointmentId &&
                item.PatientId == patientId &&
                item.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                item.StartAt > now)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(item => item.SlotId, newSlotId)
                .SetProperty(item => item.StartAt, newSlot.SlotDateTime)
                .SetProperty(item => item.EndAt, newSlot.SlotDateTime.AddMinutes(newSlot.ClinicDoctor.ConsultationDurationMinutes))
                .SetProperty(item => item.LastModificationTime, now)
                .SetProperty(item => item.LastModifierUserId, userId));
        if (updated != 1)
            return false;

        await _dbContext.Slots
            .Where(slot => slot.SlotId == appointment.SlotId)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(slot => slot.IsAvailable, true)
                .SetProperty(slot => slot.LastModificationTime, now)
                .SetProperty(slot => slot.LastModifierUserId, userId));

        await transaction.CommitAsync();
        return true;
    }
}
