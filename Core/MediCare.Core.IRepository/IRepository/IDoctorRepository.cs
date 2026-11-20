using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Base;

namespace MediCare.Core.IRepository.IRepository
{
    public  interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<Doctor?> GetDoctorById(int doctorId, string includeProperties = "");
        Task<List<Doctor>> GetDoctors(string includeProperties = "");
        Task <List<Doctor>> GetDoctorsBySpecializationId(int id, string includeProperties = "");
        Task<bool> CheckIsDoctorExist(int doctorId);
        // (i know i need to change the place for this) but i will keep it here for now and i will change it later (so please don't comment here ) 
        Task<bool> SpecializationExists(int specializationId);
    }
}
