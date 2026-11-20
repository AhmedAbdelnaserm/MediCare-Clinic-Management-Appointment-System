using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
{
    private const string DoctorIncludes = "User,Specialization,ClinicDoctors.Clinic";

    public DoctorRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<Doctor?> GetDoctorById(int doctorId, string includeProperties = "") =>
        FirstOrDefaultAsync(
            doctor => doctor.DoctorId == doctorId &&
                      doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            string.IsNullOrWhiteSpace(includeProperties) ? DoctorIncludes : includeProperties);

    public Task<List<Doctor>> GetDoctors(string includeProperties = "") =>
        GetWhereAsync(
            doctor => doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            string.IsNullOrWhiteSpace(includeProperties) ? DoctorIncludes : includeProperties);

    public Task<List<Doctor>> GetDoctorsBySpecializationId(int specializationId, string includeProperties = "") =>
        GetWhereAsync(
            doctor => doctor.SpecializationId == specializationId &&
                      doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted,
            string.IsNullOrWhiteSpace(includeProperties) ? DoctorIncludes : includeProperties);

    public Task<bool> CheckIsDoctorExist(int doctorId) =>
        AppDbContext.Doctors.AnyAsync(doctor =>
            doctor.DoctorId == doctorId &&
            doctor.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);

    public Task<bool> SpecializationExists(int specializationId) =>
        AppDbContext.Specializations.AnyAsync(specialization =>
            specialization.SpecializationId == specializationId &&
            specialization.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
}
