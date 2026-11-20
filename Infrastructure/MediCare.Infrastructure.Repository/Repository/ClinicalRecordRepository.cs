using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class ClinicalRecordRepository : IClinicalRecordRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClinicalRecordRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public Task<Doctor?> GetDoctorByUserIdAsync(string userId) => _dbContext.Doctors
        .FirstOrDefaultAsync(doctor => doctor.UserId == userId &&
            doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<List<Appointment>> GetAppointmentsAwaitingRecordAsync(string userId)
    {
        var now = DateTime.UtcNow;
        return _dbContext.Appointments.AsNoTracking()
            .Where(appointment => appointment.Slot.ClinicDoctor.Doctor.UserId == userId &&
                appointment.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                appointment.EndAt <= now && appointment.MedicalRecord == null &&
                appointment.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
            .Include(appointment => appointment.Patient).ThenInclude(patient => patient.User)
            .OrderBy(appointment => appointment.StartAt)
            .Take(100)
            .ToListAsync();
    }

    public Task<Appointment?> GetAppointmentForDoctorAsync(int appointmentId, string userId) =>
        _dbContext.Appointments
            .Include(appointment => appointment.Slot).ThenInclude(slot => slot.ClinicDoctor)
            .Include(appointment => appointment.Patient).ThenInclude(patient => patient.User)
            .Include(appointment => appointment.MedicalRecord)
            .FirstOrDefaultAsync(appointment => appointment.AppointmentId == appointmentId &&
                appointment.Slot.ClinicDoctor.Doctor.UserId == userId &&
                appointment.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                appointment.EndAt <= DateTime.UtcNow &&
                appointment.MedicalRecord == null &&
                appointment.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<List<MedicalRecord>> GetDoctorRecordsAsync(string userId) =>
        LoadRecords(_dbContext.MedicalRecords.Where(record => record.Doctor.UserId == userId));

    public Task<List<MedicalRecord>> GetPatientRecordsAsync(string userId) =>
        LoadRecords(_dbContext.MedicalRecords.Where(record => record.Patient.UserId == userId));

    public Task AddRecordAsync(MedicalRecord record) => _dbContext.MedicalRecords.AddAsync(record).AsTask();

    public Task<MedicalRecord?> GetRecordForAttachmentAsync(int medicalRecordId, string userId, bool isDoctor) =>
        _dbContext.MedicalRecords.FirstOrDefaultAsync(record => record.MedicalRecordId == medicalRecordId &&
            record.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
            (isDoctor ? record.Doctor.UserId == userId : record.Patient.UserId == userId));

    public Task<UploadedAttachment?> GetOwnedAttachmentAsync(int attachmentId, string userId, bool isDoctor) =>
        _dbContext.UploadedAttachments.Include(attachment => attachment.MedicalRecord)
            .FirstOrDefaultAsync(attachment => attachment.UploadedAttachmentId == attachmentId &&
                attachment.MedicalRecord.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                (isDoctor ? attachment.MedicalRecord.Doctor.UserId == userId : attachment.MedicalRecord.Patient.UserId == userId));

    public Task AddAttachmentAsync(UploadedAttachment attachment) => _dbContext.UploadedAttachments.AddAsync(attachment).AsTask();

    private static Task<List<MedicalRecord>> LoadRecords(IQueryable<MedicalRecord> query) => query
        .AsNoTracking()
        .Where(record => record.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
        .Include(record => record.Doctor)
        .Include(record => record.Patient).ThenInclude(patient => patient.User)
        .Include(record => record.Appointment)
        .Include(record => record.Prescriptions).ThenInclude(prescription => prescription.Items)
        .Include(record => record.UploadedAttachments)
        .OrderByDescending(record => record.Appointment.StartAt)
        .Take(200)
        .ToListAsync();
}
