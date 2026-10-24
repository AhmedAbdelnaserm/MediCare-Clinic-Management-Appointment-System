using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Authentication;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository
{
    public class AuthRepository : BaseRepository<ApplicationUser>, IAuthRepository
    {
        public AuthRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }

        public override Expression<Func<ApplicationUser, object>> ColumnsMap
            (string sortingExpression)
        {
            throw new NotImplementedException();
        }

       
    }
}
