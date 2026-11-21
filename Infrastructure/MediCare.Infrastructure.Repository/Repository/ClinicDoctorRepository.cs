using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository;

public class ClinicDoctorRepository
    : BaseRepository<ClinicDoctor>, IClinicDoctorRepository
{
    private const string DefaultIncludes =
        "Doctor.User,Doctor.Specialization,WorkingHours";

    public ClinicDoctorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override Expression<Func<ClinicDoctor, object>> ColumnsMap(string sortingExpression)
    {
        return sortingExpression?.ToLower() switch
        {
            "creationtime" => x => x.CreationTime,
            "clinicid" => x => x.ClinicId,
            "doctorid" => x => x.DoctorId,
            _ => x => x.ClinicDoctorId
        };
    }

    public Task<ClinicDoctor?> GetById(int clinicDoctorId, string includeProperties = "")
    {
        return FirstOrDefaultAsync(x =>
                x.ClinicDoctorId == clinicDoctorId &&
                x.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                x.IsActive,
            string.IsNullOrWhiteSpace(includeProperties)
                ? DefaultIncludes
                : includeProperties);
    }

    public Task<List<ClinicDoctor>> GetByClinicId(int clinicId, string includeProperties = "")
    {
        return GetWhereAsync(x =>
                x.ClinicId == clinicId &&
                x.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted &&
                x.IsActive,
            string.IsNullOrWhiteSpace(includeProperties)
                ? DefaultIncludes
                : includeProperties);
    }

    public Task<ClinicDoctor?> GetByClinicAndDoctor(int clinicId, int doctorId, string includeProperties = "")
    {
        return FirstOrDefaultAsync(x =>
                x.ClinicId == clinicId &&
                x.DoctorId == doctorId,
            string.IsNullOrWhiteSpace(includeProperties)
                ? DefaultIncludes
                : includeProperties);
    }
}