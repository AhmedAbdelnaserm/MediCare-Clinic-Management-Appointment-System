using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository;

public interface IClinicAppointmentRepository
{
    Task<List<Appointment>> GetClinicAppointmentsAsync(int clinicId);
    Task<bool> TryCancelAsync(int appointmentId, int clinicId, string userId, string? reason);
}
