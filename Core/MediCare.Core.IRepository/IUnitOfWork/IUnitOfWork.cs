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
        //ICityRepository CityRepository { get; }
        //IAreaRepository AreaRepository { get; }
        #endregion
    }
}
