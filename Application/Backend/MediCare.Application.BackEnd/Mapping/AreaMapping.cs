using AutoMapper;
using MediCare.Common.Dto;
using MediCare.Core.Entity.Entity;

namespace MediCare.Application.BackEnd.Mapping
{
    public class AreaMapping : Profile
    {
        public AreaMapping()
        {
            CreateMap<Area, TextValueBindingResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AreaId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnName));
        }
    }
}
