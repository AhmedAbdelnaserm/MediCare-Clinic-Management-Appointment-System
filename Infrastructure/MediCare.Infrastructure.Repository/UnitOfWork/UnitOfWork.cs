using MediCare.Core.IRepository.IRepository.Authentication;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.Infrastructure.Repository.Context;
using MediCare.Infrastructure.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext AppDbContext { get; }
        public UnitOfWork(ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }


        #region Main Methods Implementation 
        public Task<int> Commit()
        {
            try
            {
                return AppDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void RollBack()
        {
            var changedEntries = AppDbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
        public void Dispose() { }


        #endregion

        #region Repository
        public IAuthRepository AuthRepository => new AuthRepository(AppDbContext);

        //public ICityRepository CityRepository => new CityRepository(AppDbContext);

        //public IAreaRepository AreaRepository => new AreaRepository(AppDbContext);
        #endregion
    }
}
