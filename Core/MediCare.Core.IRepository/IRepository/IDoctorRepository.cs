using MediCare.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediCare.Core.IRepository.IRepository
{
    public  interface IDoctorRepository
    {
        Task <Doctor>CreateDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(int doctorId);
        Task<Doctor> GetDoctorById(int doctorId, string includeProperties = "");
        Task<List<Doctor>> GetDoctors(string includeProperties = "");
        Task <List<Doctor>> GetDoctorsBySpecializationId(int id, string includeProperties = "");
        Task <List<Doctor>> GetDoctorsByClinicId(int id, string includeProperties = "");
        Task <List<Doctor>> GetDoctorsByClinicIdAndSpecializationId(int clinicId, int specializationId, string includeProperties = "");
        Task<List<Appointment>> GetAppointmentsByDoctorId(int doctorId, string includeProperties = "");
        Task<List<Slot>> GetSlotsByDoctorId(int doctorId, string includeProperties = "");
        Task<bool> UserExists(string userId);
        Task<bool> DoctorExistsForUser(string userId);
        Task<bool> SpecializationExists(int specializationId);
        Task<bool> CheckIsDoctorExist(int doctorId);
        // Task<Appointment> GetAppointmentById(int appointmentId, string includeProperties = "");
        // Task<Slot> GetSlotById(int slotId, string includeProperties = "");
        // Task<Slot> CreateSlot(Slot slot);
        // Task<Slot> UpdateSlot(Slot slot);
        // Task <bool> DeleteSlot(int slotId);

    }
}
