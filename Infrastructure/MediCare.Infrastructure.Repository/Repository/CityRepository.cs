using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        { }

        public override Expression<Func<City, object>> ColumnsMap(string sortingExpression)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetCity(int cityId, string includeProperties = "")
        {
            return await FirstOrDefaultAsync(c =>c.DeleteStatusId ==(int)DeleteStatusEnum.NotDeleted && c.CityId == cityId, includeProperties);
        }

        public async Task<List<City>> GetCities(string includeProperties = "")
        {
            return await GetWhereAsync(c => c.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties);
        }
    }
}
