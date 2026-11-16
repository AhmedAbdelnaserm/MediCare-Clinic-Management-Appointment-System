using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediCare.Application.BackEnd.Dto.Dto.Specialization;

namespace MediCare.IApplication.BackEnd.IAppService
{


    
        public interface ISpecializationAppService
        {
            Task<IEnumerable<SpecializationDto>> GetAllAsync(string culture = "en");
            Task<SpecializationDto?> GetByIdAsync(int id, string culture = "en");
            Task<SpecializationDto> CreateAsync(CreateSpecializationDto dto);
            Task<bool> UpdateAsync(UpdateSpecializationDto dto);
            Task<bool> DeleteAsync(int id);
        }
    
}
