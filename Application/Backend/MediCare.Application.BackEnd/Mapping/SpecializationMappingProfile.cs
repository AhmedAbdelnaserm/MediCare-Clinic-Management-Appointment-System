using AutoMapper;
using global::MediCare.Application.BackEnd.Dto.Dto.Specialization;
using global::MediCare.Core.Entity.Entity;
namespace MediCare.Application.BackEnd.Mapping
{



        public class SpecializationMappingProfile : Profile
        {
            public SpecializationMappingProfile()
            {
                CreateMap<Specialization, SpecializationDto>()
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.EnName))
                    .ForMember(dest => dest.DisplayDescription, opt => opt.MapFrom(src => src.EnDescription));

                CreateMap<CreateSpecializationDto, Specialization>();
                CreateMap<UpdateSpecializationDto, Specialization>();
            }
        }
    
}
