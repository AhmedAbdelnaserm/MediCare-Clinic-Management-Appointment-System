using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace MediCare.Core.IRepository.IRepository;

public interface IClinicDoctorRepository : IBaseRepository<ClinicDoctor>
{
    Task<ClinicDoctor?> GetById(int clinicDoctorId, string includeProperties = "");

    Task<List<ClinicDoctor>> GetByClinicId(int clinicId, string includeProperties = "");

    Task<ClinicDoctor?> GetByClinicAndDoctor(int clinicId, int doctorId, string includeProperties = "");
    Task<List<ClinicDoctor>> GetByDoctorId(int doctorId, string includeProperties = "");
    IDbContextTransaction BeginScheduleUpdateTransaction();
}