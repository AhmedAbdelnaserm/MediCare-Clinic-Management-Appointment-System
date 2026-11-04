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
        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await CreateAsync(doctor);
            return doctor;
        }

        public Task<bool> UserExists(string userId) =>
            AppDbContext.Users.AnyAsync(user => user.Id == userId);

        public Task<bool> DoctorExistsForUser(string userId) =>
            AppDbContext.Doctors.AnyAsync(doctor => doctor.UserId == userId);

        public Task<bool> SpecializationExists(int specializationId) =>
            AppDbContext.Specializations.AnyAsync(specialization => specialization.SpecializationId == specializationId);

        public Task<bool> CheckIsDoctorExist(int doctorId) =>
            AppDbContext.Doctors.AnyAsync(doctor => doctor.DoctorId == doctorId && doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            Update(doctor);
            return doctor;
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
       public async Task<List<Doctor>> GetDoctorsByClinicIdAndSpecializationId(int clinicId, int specializationId, string includeProperties = "")
        {
            var result = await GetWhereAsync(d => d.ClinicDoctors.Any(cd => cd.ClinicId == clinicId) && d.SpecializationId == specializationId && d.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties == "" ? DoctorIncludes : includeProperties);
            return  result;
               
        }

        public async Task<List<Doctor>> GetDoctorsBySpecializationId(int id, string includeProperties = "")
        {
            var result = await GetWhereAsync(d => d.SpecializationId == id && d.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties == "" ? DoctorIncludes : includeProperties);
            return result;
        }
        public async Task<List<Doctor>> GetDoctorsByClinicId(int id, string includeProperties = "")
        {
            var result = await GetWhereAsync(d => d.ClinicDoctors.Any(cd => cd.ClinicId == id) && d.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted, includeProperties == "" ? DoctorIncludes : includeProperties);
            return result;
        }
   
        public async Task<List<Appointment>> GetAppointmentsByDoctorId(int doctorId, string includeProperties = "")
        {
           IQueryable<Appointment> query = AppDbContext.Set<Appointment>().Where(a => a.Slot.ClinicDoctor.DoctorId == doctorId && a.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted).Include(a => a.Patient).ThenInclude(p => p.User);
           foreach (var include in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries)) query = query.Include(include);
           var result=await query.ToListAsync();
            return result;
        }
      
        public async Task<List<Slot>> GetSlotsByDoctorId(int doctorId, string includeProperties = "")
        {
            IQueryable<Slot> query = AppDbContext.Set<Slot>().Where(s => s.ClinicDoctor.DoctorId == doctorId && s.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted).Include(s => s.Appointments.Where(a => a.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)).ThenInclude(a => a.Patient).ThenInclude(p => p!.User);
            foreach (var include in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries)) query = query.Include(include);
            var result = await query.ToListAsync();
            return result;
        }
    }
}
