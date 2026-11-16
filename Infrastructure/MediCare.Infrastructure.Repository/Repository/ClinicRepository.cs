
using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository
{
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        { }

        public override Expression<Func<Clinic, object>> ColumnsMap(string sortingExpression)
        {
            return sortingExpression switch
            {
                nameof(Clinic.EnName) => x => x.EnName,
                nameof(Clinic.ArName) => x => x.ArName,
                nameof(Clinic.Address) => x => x.Address,
                nameof(Clinic.CreationTime) => x => x.CreationTime,
                _ => x => x.ClinicId
            };
        }

        public async Task<Clinic> GetClinic(int clinicId, string includeProperties = "")
        {
            return await FirstOrDefaultAsync(c => c.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted && c.ClinicId == clinicId, includeProperties);
        }

        public async Task<List<Clinic>> GetClinics(string includeProperties = "")
        {
            return await GetWhereAsync(c => c.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties);
        }

        public async Task<List<Clinic>> GetClinicsByAreaId(int areaId, string includeProperties = "")
        {
            return await GetWhereAsync(c => c.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted && c.AreaId == areaId, includeProperties);
        }
    }
}
