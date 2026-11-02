using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository
{
    public interface ICityRepository
    {
        Task<City> GetCity(int cityId, string includeProperties = "");
        Task<List<City>> GetCities(string includeProperties = "");
    }
}
