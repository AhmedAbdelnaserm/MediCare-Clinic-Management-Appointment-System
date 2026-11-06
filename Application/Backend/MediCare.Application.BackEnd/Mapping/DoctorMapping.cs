using AutoMapper;
using MediCare.Common.Dto;
using MediCare.Core.Entity.Entity;
using MediCare.Application.BackEnd.Dto.Dto;

namespace MediCare.Application.BackEnd.Mapping;

public class DoctorMapping : Profile
{
    public DoctorMapping()
    {
        CreateMap<Doctor, DoctorResponseDto>()
            .ForMember(dest => dest.DoctorName,opt => opt.MapFrom(src => src.EnName))
          .ForMember(dest => dest.UserId,opt => opt.MapFrom(src => src.UserId))
          .ForMember(dest => dest.DoctorEmail,opt => opt.MapFrom(src => src.User == null? string.Empty : src.User.Email ?? string.Empty))
          .ForMember(dest => dest.DoctorPhone,opt => opt.MapFrom(src => src.User == null? string.Empty : src.User.PhoneNumber ?? string.Empty))
          .ForMember(dest => dest.SpecializationName,opt => opt.MapFrom(src => src.Specialization.EnName))
          .ForMember(dest => dest.ClinicName,opt => opt.MapFrom(src => src.ClinicDoctors.Select(cd => cd.Clinic.EnName).FirstOrDefault() ?? string.Empty))
          .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.EnDescription));

        CreateMap<UpdateDoctorRequestDto, Doctor>()
            .ForMember(dest => dest.DoctorId, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Specialization, opt => opt.Ignore())
            .ForMember(dest => dest.ClinicDoctors, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalRecords, opt => opt.Ignore());

        CreateMap<CreateDoctorRequestDto, Doctor>()
         .ForMember(dest => dest.UserId,opt => opt.MapFrom(src => src.UserId))
         .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
         .ForMember(dest => dest.ConsultationFee,opt => opt.MapFrom(src => src.ConsultationFee))
         .ForMember(dest => dest.EnName,opt => opt.MapFrom(src => src.EnName))
         .ForMember(dest => dest.EnDescription,opt => opt.MapFrom(src => src.EnDescription))
         .ForMember(dest => dest.ProfileImage,opt => opt.MapFrom(src => src.ProfileImage))
         .ForMember(dest => dest.DoctorDegree,opt => opt.MapFrom(src => src.DoctorDegree));
    }
}
