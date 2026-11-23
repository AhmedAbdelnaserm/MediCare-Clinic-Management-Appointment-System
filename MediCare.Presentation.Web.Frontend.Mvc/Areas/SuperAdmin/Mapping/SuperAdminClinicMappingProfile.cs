using AutoMapper;
using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.Mapping;

public sealed class SuperAdminClinicMappingProfile : Profile
{
    public SuperAdminClinicMappingProfile()
    {
        CreateMap<ClinicDto, ClinicFormViewModel>();
        CreateMap<ClinicFormViewModel, CreateClinicRequestDto>();
        CreateMap<ClinicFormViewModel, UpdateClinicRequestDto>();
    }
}
