using AutoMapper;
using MediCare.Common.Dto;
using MediCare.Core.Entity.Entity;

namespace MediCare.Application.BackEnd.Mapping
{
    public class CityMapping : Profile
    {
        public CityMapping()
        {
            CreateMap<City, TextValueBindingResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CityId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnName));
        }
    }
}
