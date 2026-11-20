using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class AreaRepository : BaseRepository<Area>, IAreaRepository
{
    public AreaRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<Area?> GetArea(int areaId, string includeProperties = "") =>
        FirstOrDefaultAsync(area =>
            area.AreaId == areaId && area.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            includeProperties);

    public Task<List<Area>> GetAreas(string includeProperties = "") =>
        GetWhereAsync(area => area.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties);

    public Task<bool> CheckIsAreaExist(int areaId) =>
        GetAnyAsync(area => area.AreaId == areaId &&
                            area.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<List<Area>> GetAreasByCityId(int cityId, string includeProperties = "") =>
        GetWhereAsync(area => area.CityId == cityId &&
                              area.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            includeProperties);
}
