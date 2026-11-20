using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository;

public interface IClinicScheduleRepository
{
    Task<bool> ClinicExistsAsync(int clinicId);
    Task<bool> DoctorExistsAsync(int doctorId);
    Task<ClinicDoctor?> GetClinicDoctorAsync(int clinicDoctorId);
    Task<List<ClinicDoctor>> GetClinicDoctorLinksAsync();
    Task<bool> ClinicDoctorLinkExistsAsync(int clinicId, int doctorId);
    Task AddClinicDoctorAsync(ClinicDoctor clinicDoctor);
    Task ReplaceWorkingHoursAsync(int clinicDoctorId, IReadOnlyCollection<WorkingHour> workingHours, string userId);
    Task<List<DateTime>> GetSlotTimesAsync(int clinicDoctorId, DateOnly startDate, DateOnly endDate);
    Task AddSlotsAsync(IReadOnlyCollection<Slot> slots);
    Task<List<ScheduleException>> GetScheduleExceptionsAsync(int clinicDoctorId, DateOnly startDate, DateOnly endDate);
    Task SaveScheduleExceptionAsync(int clinicDoctorId, ScheduleException exception, string userId);
    Task DeleteScheduleExceptionAsync(int clinicDoctorId, int exceptionId);
}
