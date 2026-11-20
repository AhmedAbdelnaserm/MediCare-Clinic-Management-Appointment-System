using MediCare.Core.IRepository.IRepository;
using MediCare.Core.IRepository.IRepository.Authentication;

namespace MediCare.Core.IRepository.IUnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        #region Main Methods
        Task<int> Commit();
        void RollBack();
        #endregion

        #region IRepoository
        ICityRepository CityRepository { get; }
        IAreaRepository AreaRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IClinicRepository ClinicRepository { get; }
        IClinicStaffRepository ClinicStaffRepository { get; }
        IPatientRepository PatientRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IClinicScheduleRepository ClinicScheduleRepository { get; }
        IClinicalRecordRepository ClinicalRecordRepository { get; }
        IClinicAppointmentRepository ClinicAppointmentRepository { get; }
        IUserNotificationRepository UserNotificationRepository { get; }
        #endregion
    }
}
