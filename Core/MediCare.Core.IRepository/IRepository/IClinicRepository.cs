using MediCare.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediCare.Core.IRepository.IRepository
{
    public interface IClinicRepository
    {
        Task<Clinic> GetClinic(int clinicId, string includeProperties = "");
        Task<List<Clinic>> GetClinics(string includeProperties = "");
        Task<List<Clinic>> GetClinicsByAreaId(int areaId, string includeProperties = "");

        Task<bool> CreateClinic(Clinic clinic);
        Task<bool> UpdateClinic(Clinic clinic);
        Task<bool> DeleteClinic(Clinic clinic);
    }
}
