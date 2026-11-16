using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Core.IRepository.IRepository.Authentication;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository;

public class ClinicStaffRepository
    : BaseRepository<ClinicStaff>, IClinicStaffRepository
{
    private readonly ApplicationDbContext _context;

    public ClinicStaffRepository(ApplicationDbContext appDbContext)
        : base(appDbContext)
    {
        _context = appDbContext;
    }

    public override Expression<Func<ClinicStaff, object>> ColumnsMap(
        string sortingExpression)
    {
        return sortingExpression?.ToLower() switch
        {
            "creationtime" => x => x.CreationTime,
            "clinicid" => x => x.ClinicId,
            _ => x => x.ClinicStaffId
        };
    }

    public Task<ClinicStaff?> GetByUserId(string userId)
    {
        return _context.ClinicStaffs
            .Include(x => x.User)
            .Include(x => x.Clinic)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public Task<List<ClinicStaff>> GetClinicStaffs()
    {
        return _context.ClinicStaffs
            .Include(x => x.User)
            .Include(x => x.Clinic)
            .ToListAsync();
    }
}