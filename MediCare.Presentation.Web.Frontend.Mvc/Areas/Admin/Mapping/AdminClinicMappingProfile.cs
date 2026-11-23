using AutoMapper;
using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.ViewModels;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.Mapping;

public sealed class AdminClinicMappingProfile : Profile
{
    public AdminClinicMappingProfile()
    {
        CreateMap<ClinicDto, ClinicFormViewModel>();
        CreateMap<ClinicFormViewModel, UpdateClinicRequestDto>();
    }
}
