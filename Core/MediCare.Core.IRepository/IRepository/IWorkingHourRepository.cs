using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Base;

namespace MediCare.Core.IRepository.IRepository;

public interface IWorkingHourRepository : IBaseRepository<WorkingHour>
{
    Task<List<WorkingHour>> GetByClinicDoctorId(int clinicDoctorId);
}