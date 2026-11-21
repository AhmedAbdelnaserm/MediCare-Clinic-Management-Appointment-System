using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository;

public class WorkingHourRepository : BaseRepository<WorkingHour>, IWorkingHourRepository
{
    public WorkingHourRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override Expression<Func<WorkingHour, object>> ColumnsMap(string sortingExpression)
    {
        return sortingExpression?.ToLower() switch
        {
            "dayofweek" => x => x.DayOfWeek,
            "starttime" => x => x.StartTime,
            _ => x => x.WorkingHourId
        };
    }

    public Task<List<WorkingHour>> GetByClinicDoctorId(int clinicDoctorId)
    {
        return GetWhereAsync(x =>
        x.ClinicDoctorId == clinicDoctorId &&
        x.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
    }
}