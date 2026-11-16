using MediCare.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediCare.Core.IRepository.IRepository
{
    public  interface IDoctorRepository
    {
        Task CreateDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(int doctorId);
        Task<Doctor> GetDoctorById(int doctorId, string includeProperties = "");
        Task<List<Doctor>> GetDoctors(string includeProperties = "");
        Task <List<Doctor>> GetDoctorsBySpecializationId(int id, string includeProperties = "");
        Task<bool> CheckIsDoctorExist(int doctorId);
        // (i know i need to change the place for this) but i will keep it here for now and i will change it later (so please don't comment here ) 
        Task<bool> SpecializationExists(int specializationId);

    }
}
