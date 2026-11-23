using AutoMapper;
using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.Mapping;

public sealed class DoctorProfileViewMapping : Profile
{
    public DoctorProfileViewMapping()
    {
        CreateMap<SpecializationOptionDto, SelectListItem>()
            .ForMember(destination => destination.Text, options => options.MapFrom(source => source.Name))
            .ForMember(destination => destination.Value, options => options.MapFrom(source => source.Value));

        CreateMap<DoctorProfileDto, DoctorFormViewModel>()
            .ForMember(destination => destination.Specializations,
                options => options.MapFrom(source => source.Specializations));

        CreateMap<DoctorFormViewModel, UpdateDoctorProfileRequestDto>();
    }
}
