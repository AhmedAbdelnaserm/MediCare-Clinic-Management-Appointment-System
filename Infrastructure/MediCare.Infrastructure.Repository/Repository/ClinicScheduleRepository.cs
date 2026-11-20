using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class ClinicScheduleRepository : IClinicScheduleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClinicScheduleRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public Task<bool> ClinicExistsAsync(int clinicId) => _dbContext.Clinics.AnyAsync(clinic =>
        clinic.ClinicId == clinicId && clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<bool> DoctorExistsAsync(int doctorId) => _dbContext.Doctors.AnyAsync(doctor =>
        doctor.DoctorId == doctorId && doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<ClinicDoctor?> GetClinicDoctorAsync(int clinicDoctorId) => _dbContext.ClinicDoctors
        .Include(link => link.WorkingHours)
        .Include(link => link.Clinic)
        .Include(link => link.Doctor)
        .FirstOrDefaultAsync(link => link.ClinicDoctorId == clinicDoctorId &&
            link.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<List<ClinicDoctor>> GetClinicDoctorLinksAsync() => _dbContext.ClinicDoctors
        .AsNoTracking()
        .Where(link => link.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
        .Include(link => link.Clinic)
        .Include(link => link.Doctor).ThenInclude(doctor => doctor.Specialization)
        .Include(link => link.WorkingHours)
        .OrderBy(link => link.Clinic.EnName)
        .ThenBy(link => link.Doctor.EnName)
        .ToListAsync();

    public Task<bool> ClinicDoctorLinkExistsAsync(int clinicId, int doctorId) => _dbContext.ClinicDoctors.AnyAsync(link =>
        link.ClinicId == clinicId && link.DoctorId == doctorId &&
        link.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task AddClinicDoctorAsync(ClinicDoctor clinicDoctor) => _dbContext.ClinicDoctors.AddAsync(clinicDoctor).AsTask();

    public async Task ReplaceWorkingHoursAsync(
        int clinicDoctorId,
        IReadOnlyCollection<WorkingHour> workingHours,
        string userId)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var existing = await _dbContext.WorkingHours
            .Where(hour => hour.ClinicDoctorId == clinicDoctorId)
            .ToListAsync();

        _dbContext.WorkingHours.RemoveRange(existing);
        foreach (var hour in workingHours)
        {
            hour.ClinicDoctorId = clinicDoctorId;
            hour.CreationTime = DateTime.UtcNow;
            hour.CreatorUserId = userId;
        }

        await _dbContext.WorkingHours.AddRangeAsync(workingHours);
        await _dbContext.Slots
            .Where(slot => slot.ClinicDoctorId == clinicDoctorId && slot.IsAvailable &&
                           slot.SlotDateTime > DateTime.UtcNow)
            .ExecuteDeleteAsync();

        await _dbContext.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public Task<List<DateTime>> GetSlotTimesAsync(int clinicDoctorId, DateOnly startDate, DateOnly endDate)
    {
        var start = startDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
        var end = endDate.AddDays(1).ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);

        return _dbContext.Slots.AsNoTracking()
            .Where(slot => slot.ClinicDoctorId == clinicDoctorId &&
                           slot.SlotDateTime >= start && slot.SlotDateTime < end)
            .Select(slot => slot.SlotDateTime)
            .ToListAsync();
    }

    public async Task AddSlotsAsync(IReadOnlyCollection<Slot> slots)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        await _dbContext.Slots.AddRangeAsync(slots);
        await _dbContext.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public Task<List<ScheduleException>> GetScheduleExceptionsAsync(int clinicDoctorId, DateOnly startDate, DateOnly endDate) =>
        _dbContext.ScheduleExceptions.AsNoTracking()
            .Where(item => item.ClinicDoctorId == clinicDoctorId && item.ExceptionDate >= startDate && item.ExceptionDate <= endDate)
            .OrderBy(item => item.ExceptionDate).ToListAsync();

    public async Task SaveScheduleExceptionAsync(int clinicDoctorId, ScheduleException exception, string userId)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var existing = await _dbContext.ScheduleExceptions.FirstOrDefaultAsync(item =>
            item.ClinicDoctorId == clinicDoctorId && item.ExceptionDate == exception.ExceptionDate);
        if (existing is null)
        {
            exception.ClinicDoctorId = clinicDoctorId;
            exception.CreationTime = DateTime.UtcNow;
            exception.CreatorUserId = userId;
            await _dbContext.ScheduleExceptions.AddAsync(exception);
        }
        else
        {
            existing.IsClosed = exception.IsClosed;
            existing.StartTime = exception.StartTime;
            existing.EndTime = exception.EndTime;
            existing.Reason = exception.Reason;
            existing.LastModificationTime = DateTime.UtcNow;
            existing.LastModifierUserId = userId;
        }

        var dayStart = exception.ExceptionDate.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
        var dayEnd = dayStart.AddDays(1);
        await _dbContext.Slots.Where(slot => slot.ClinicDoctorId == clinicDoctorId && slot.IsAvailable &&
                slot.SlotDateTime >= dayStart && slot.SlotDateTime < dayEnd)
            .ExecuteDeleteAsync();
        await _dbContext.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public async Task DeleteScheduleExceptionAsync(int clinicDoctorId, int exceptionId)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        var exception = await _dbContext.ScheduleExceptions.FirstOrDefaultAsync(item =>
            item.ScheduleExceptionId == exceptionId && item.ClinicDoctorId == clinicDoctorId);
        if (exception is not null)
            _dbContext.ScheduleExceptions.Remove(exception);
        await _dbContext.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}
