using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }

        public override Expression<Func<Area, object>> ColumnsMap(string sortingExpression)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Area>> GetAreas(string includeProperties = "")
        {
            return await GetWhereAsync(a => a.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties);
        }

        public async Task<Area> GetArea(int areaId, string includeProperties = "")
        {
            return await FirstOrDefaultAsync(a => a.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted && a.AreaId == areaId, includeProperties);
        }
        public async Task<bool> CheckIsAreaExist(int areaId)
        {
            return await GetAnyAsync(src => src.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted && src.AreaId == areaId);
        }

        public async Task<List<Area>> GetAreasByCityId(int id, string includeProperties = "")
        {
            return await GetWhereAsync(a => a.CityId == id && a.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties);
        }
    }
}
