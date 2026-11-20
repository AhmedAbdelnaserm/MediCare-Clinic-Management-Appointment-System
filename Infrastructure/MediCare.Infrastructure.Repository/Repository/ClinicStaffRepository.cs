using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Authentication;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class ClinicStaffRepository : BaseRepository<ClinicStaff>, IClinicStaffRepository
{
    public ClinicStaffRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<ClinicStaff?> GetByUserId(string userId) =>
        AppDbContext.ClinicStaffs
            .Include(staff => staff.User)
            .Include(staff => staff.Clinic)
            .FirstOrDefaultAsync(staff => staff.UserId == userId &&
                                          staff.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<List<ClinicStaff>> GetClinicStaffs() =>
        AppDbContext.ClinicStaffs
            .Include(staff => staff.User)
            .Include(staff => staff.Clinic)
            .Where(staff => staff.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
            .ToListAsync();
}
