using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository
{
    public interface IAreaRepository
    {
        Task<Area> GetArea(int areaId, string includeProperties = "");
        Task<List<Area>> GetAreas(string includeProperties = "");
        Task<List<Area>> GetAreasByCityId(int id, string includeProperties = "");
        Task<bool> CheckIsAreaExist(int areaId);
        
    }
}
