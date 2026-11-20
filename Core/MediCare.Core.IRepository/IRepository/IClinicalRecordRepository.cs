using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository;

public interface IClinicalRecordRepository
{
    Task<Doctor?> GetDoctorByUserIdAsync(string userId);
    Task<List<Appointment>> GetAppointmentsAwaitingRecordAsync(string userId);
    Task<Appointment?> GetAppointmentForDoctorAsync(int appointmentId, string userId);
    Task<List<MedicalRecord>> GetDoctorRecordsAsync(string userId);
    Task<List<MedicalRecord>> GetPatientRecordsAsync(string userId);
    Task AddRecordAsync(MedicalRecord record);
    Task<MedicalRecord?> GetRecordForAttachmentAsync(int medicalRecordId, string userId, bool isDoctor);
    Task<UploadedAttachment?> GetOwnedAttachmentAsync(int attachmentId, string userId, bool isDoctor);
    Task AddAttachmentAsync(UploadedAttachment attachment);
}
