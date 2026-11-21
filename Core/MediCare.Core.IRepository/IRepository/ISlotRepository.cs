using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Base;

namespace MediCare.Core.IRepository.IRepository;

public interface ISlotRepository : IBaseRepository<Slot>
{
    Task<List<Slot>> GetByClinicDoctorId(int clinicDoctorId, DateTime fromDate);
}