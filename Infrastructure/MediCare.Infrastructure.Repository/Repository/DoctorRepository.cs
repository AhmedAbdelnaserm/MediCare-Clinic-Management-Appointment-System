using MediCare.Infrastructure.Repository.Base;
using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Repository
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        private const string DoctorIncludes = "User,Specialization,ClinicDoctors.Clinic";
        public DoctorRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
        public override Expression<Func<Doctor, object>> ColumnsMap(string sortingExpression)
        {
            throw new NotImplementedException();
        }
        public async Task CreateDoctor(Doctor doctor)
        {
            await CreateAsync(doctor);
        }
        public Task<bool> CheckIsDoctorExist(int doctorId)
        { return AppDbContext.Doctors.AnyAsync(doctor => doctor.DoctorId == doctorId && doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted); }
        public Task<bool> SpecializationExists(int specializationId)
        { return AppDbContext.Specializations.AnyAsync(specialization => specialization.SpecializationId == specializationId); }
        public Task UpdateDoctor(Doctor doctor)
        {
            Update(doctor);
            return Task.CompletedTask;
        }
        public async Task<bool> DeleteDoctor(int doctorId)
        {
            var doctor = await FirstOrDefaultAsync(d => d.DoctorId == doctorId && d.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
            if (doctor != null)
            {
                doctor.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
                Update(doctor);
                return true;
            }
            return false;
        }

        public async Task<Doctor> GetDoctorById(int doctorId, string includeProperties = "")
        {
            var result = await FirstOrDefaultAsync(d => d.DoctorId == doctorId && d.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties == "" ? DoctorIncludes : includeProperties);
            return result;
        }
        public async Task<List<Doctor>> GetDoctors(string includeProperties = "")
        {
            var result=await GetWhereAsync(d => d.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties == "" ? DoctorIncludes : includeProperties);
            return result;
        }
        public async Task<List<Doctor>> GetDoctorsBySpecializationId(int specializationId, string includeProperties = "")
        {
            var result = await GetWhereAsync(d => d.SpecializationId == specializationId && d.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties == "" ? DoctorIncludes : includeProperties);
            return result;
        }

    }
}
