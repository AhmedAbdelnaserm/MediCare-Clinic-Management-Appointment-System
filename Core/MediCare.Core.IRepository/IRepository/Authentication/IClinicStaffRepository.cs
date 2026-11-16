using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Base;

namespace MediCare.Core.IRepository.IRepository.Authentication
{
    public interface IClinicStaffRepository : IBaseRepository<ClinicStaff>
    {
        Task<ClinicStaff?> GetByUserId(string userId);
        Task<List<ClinicStaff>> GetClinicStaffs();
    }
}
