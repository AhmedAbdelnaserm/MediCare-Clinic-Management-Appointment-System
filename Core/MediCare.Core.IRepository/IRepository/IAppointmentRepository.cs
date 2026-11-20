using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository;

public interface IAppointmentRepository
{
    Task<List<Slot>> GetAvailableSlotsAsync(int? doctorId);
    Task<List<Appointment>> GetPatientAppointmentsAsync(int patientId);
    Task<Appointment?> TryBookSlotAsync(int slotId, int patientId, string bookedByUserId);
    Task<bool> TryRescheduleAsync(int appointmentId, int newSlotId, int patientId, string userId);
    Task<bool> TryCancelAsync(int appointmentId, int patientId, string userId, string? reason);
}
