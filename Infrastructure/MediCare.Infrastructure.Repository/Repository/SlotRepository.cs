using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository;

public class SlotRepository : BaseRepository<Slot>, ISlotRepository
{
    public SlotRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override Expression<Func<Slot, object>> ColumnsMap(string sortingExpression)
    {
        return sortingExpression?.ToLower() switch
        {
            "slotdatetime" => x => x.SlotDateTime,
            _ => x => x.SlotId
        };
    }

    public Task<List<Slot>> GetByClinicDoctorId(int clinicDoctorId, DateTime fromDate)
    {
        return GetWhereAsync(x =>
                x.ClinicDoctorId == clinicDoctorId &&
                x.SlotDateTime >= fromDate, nameof(Slot.Appointments));
    }
}