using AutoMapper;
using MediCare.Application.Identity.Dto.ClinicAdminDto;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.Mapping;

public sealed class SuperAdminClinicAdminMappingProfile : Profile
{
    public SuperAdminClinicAdminMappingProfile()
    {
        CreateMap<ClinicAdminDto, UpdateClinicAdminRequestDto>();
    }
}
