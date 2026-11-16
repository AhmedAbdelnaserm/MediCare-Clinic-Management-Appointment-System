
using AutoMapper;
using MediCare.Application.BackEnd.Dto.ClinicDto;
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

            CreateMap<Clinic, ClinicDto>()
                .ForMember(dest => dest.ClinicId, opt => opt.MapFrom(src => src.ClinicId))
                .ForMember(dest => dest.EnName, opt => opt.MapFrom(src => src.EnName))
                .ForMember(dest => dest.EnDescription, opt => opt.MapFrom(src => src.EnDescription))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Area.CityId))
                .ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId))
                .ForMember(dest => dest.AreaName, opt => opt.MapFrom(src => src.Area.EnName));

            // Create
            CreateMap<CreateClinicRequestDto, Clinic>()
                .ForMember(dest => dest.ClinicId, opt => opt.Ignore())
                .ForMember(dest => dest.ArName, opt => opt.MapFrom(src => string.Empty))
                .ForMember(dest => dest.ArDescription, opt => opt.MapFrom(src => string.Empty))
                .ForMember(dest => dest.Area, opt => opt.Ignore())
                .ForMember(dest => dest.ClinicDoctors, opt => opt.Ignore())
                .ForMember(dest => dest.DeleteStatusId, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.LastModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorUserId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifierUserId, opt => opt.Ignore());

            // Update
            CreateMap<UpdateClinicRequestDto, Clinic>()
                .ForMember(dest => dest.ClinicId, opt => opt.Ignore())
                .ForMember(dest => dest.ArName, opt => opt.Ignore())
                .ForMember(dest => dest.ArDescription, opt => opt.Ignore())
                .ForMember(dest => dest.Area, opt => opt.Ignore())
                .ForMember(dest => dest.ClinicDoctors, opt => opt.Ignore())
                .ForMember(dest => dest.DeleteStatusId, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.LastModificationTime, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorUserId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifierUserId, opt => opt.Ignore());
        }
    }
}
