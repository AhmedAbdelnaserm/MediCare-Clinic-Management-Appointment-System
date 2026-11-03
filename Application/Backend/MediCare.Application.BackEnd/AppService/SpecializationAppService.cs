using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using global::MediCare.Application.BackEnd.Dto.Dto.Specialization;
using global::MediCare.Core.Entity.Entity;
using global::MediCare.Core.IRepository.IRepository;
using global::MediCare.IApplication.BackEnd.IAppService;


namespace MediCare.Application.BackEnd.AppService
{



        public class SpecializationAppService : ISpecializationAppService
        {
            private readonly IGenericRepository<Specialization> _repository;

            public SpecializationAppService(IGenericRepository<Specialization> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<SpecializationDto>> GetAllAsync(string culture = "en")
            {
                var entities = await _repository.GetAllAsync();
                return entities.Select(e => MapToDto(e, culture));
            }

            public async Task<SpecializationDto?> GetByIdAsync(int id, string culture = "en")
            {
                var entity = await _repository.GetByIdAsync(id);
                return entity == null ? null : MapToDto(entity, culture);
            }

            public async Task<SpecializationDto> CreateAsync(CreateSpecializationDto dto)
            {
                var entity = new Specialization
                {
                    EnName = dto.EnName.Trim(),
                    ArName = dto.ArName.Trim(),
                    EnDescription = dto.EnDescription?.Trim(),
                    ArDescription = dto.ArDescription?.Trim()
                };

                var created = await _repository.AddAsync(entity);
                return MapToDto(created, "en");
            }

            public async Task<bool> UpdateAsync(UpdateSpecializationDto dto)
            {
                var entity = await _repository.GetByIdAsync(dto.SpecializationId);
                if (entity == null) return false;

                entity.EnName = dto.EnName.Trim();
                entity.ArName = dto.ArName.Trim();
                entity.EnDescription = dto.EnDescription?.Trim();
                entity.ArDescription = dto.ArDescription?.Trim();

                await _repository.UpdateAsync(entity);
                return true;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return false;

                await _repository.DeleteAsync(entity);
                return true;
            }

            private static SpecializationDto MapToDto(Specialization entity, string culture)
            {
                var isArabic = culture.StartsWith("ar", StringComparison.OrdinalIgnoreCase);

                return new SpecializationDto
                {
                    SpecializationId = entity.SpecializationId,
                    EnName = entity.EnName,
                    ArName = entity.ArName,
                    EnDescription = entity.EnDescription,
                    ArDescription = entity.ArDescription,
                    DisplayName = isArabic ? entity.ArName : entity.EnName,
                    DisplayDescription = isArabic ? entity.ArDescription : entity.EnDescription
                };
            }
        }
    }



