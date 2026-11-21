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
        IAuthRepository AuthRepository { get; }
        ICityRepository CityRepository { get; }
        IAreaRepository AreaRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IClinicRepository ClinicRepository { get; }
        IClinicStaffRepository ClinicStaffRepository { get; }
        IClinicDoctorRepository ClinicDoctorRepository { get; }
        IWorkingHourRepository WorkingHourRepository { get; }
        ISlotRepository SlotRepository { get; }
        #endregion
    }
}
