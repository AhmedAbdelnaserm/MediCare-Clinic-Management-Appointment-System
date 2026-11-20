using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<City?> GetCity(int cityId, string includeProperties = "") =>
        FirstOrDefaultAsync(city =>
            city.CityId == cityId && city.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            includeProperties);

    public Task<List<City>> GetCities(string includeProperties = "") =>
        GetWhereAsync(city => city.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties);
}
