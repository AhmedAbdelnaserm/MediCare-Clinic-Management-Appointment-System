
using AutoMapper;
using MediCare.Common.Dto;
using MediCare.Core.Entity.Entity;

namespace MediCare.Application.BackEnd.Mapping
{
    public class ClinicMapping : Profile
    {
        public ClinicMapping()
        {
            CreateMap<Clinic, TextValueBindingResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClinicId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnName));

            CreateMap<Clinic, ClinicDto>();

            CreateMap<SaveClinicDto, Clinic>();
        }
    }
}
