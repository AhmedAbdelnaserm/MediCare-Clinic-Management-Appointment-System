using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
{
    public ClinicRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<Clinic?> GetClinic(int clinicId, string includeProperties = "") =>
        FirstOrDefaultAsync(clinic =>
            clinic.ClinicId == clinicId &&
            clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            includeProperties);

    public Task<List<Clinic>> GetClinics(string includeProperties = "") =>
        GetWhereAsync(clinic => clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties);

    public Task<List<Clinic>> GetClinicsByAreaId(int areaId, string includeProperties = "") =>
        GetWhereAsync(clinic => clinic.AreaId == areaId &&
                                clinic.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            includeProperties);
}
