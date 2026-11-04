using AutoMapper;
using MediCare.Common.Dto;
using MediCare.Core.Entity.Entity;
using MediCare.Application.BackEnd.Dto.Dto;
using MediCare.Common.Enum;

namespace MediCare.Application.BackEnd.Mapping;

public class DoctorMapping : Profile
{
    public DoctorMapping()
    {
        CreateMap<DoctorRequestDto, Doctor>()
            .ForMember(dest => dest.DoctorId, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.ClinicDoctors, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalRecords, opt => opt.Ignore());

        CreateMap<Doctor, DoctorResponseDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.User.FullName ?? src.User.UserName ?? string.Empty))
            .ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.User.Email ?? string.Empty))
            .ForMember(dest => dest.DoctorPhone, opt => opt.MapFrom(src => src.User.PhoneNumber ?? string.Empty))
            .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
            .ForMember(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.Specialization.EnName))
            .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.ClinicDoctors.Select(cd => cd.Clinic.EnName).FirstOrDefault() ?? string.Empty))
            .ForMember(dest => dest.DoctorDegree, opt => opt.MapFrom(src => src.DoctorDegree))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.EnDescription));

        CreateMap<Appointment, AppointmentResponseDto>()
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.User == null ? string.Empty : src.Patient.User.FullName ?? src.Patient.User.UserName ?? string.Empty))
            .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient.User == null ? string.Empty : src.Patient.User.Email ?? string.Empty))
            .ForMember(dest => dest.PatientPhoneNumber, opt => opt.MapFrom(src => src.Patient.User == null ? string.Empty : src.Patient.User.PhoneNumber ?? string.Empty))
            .ForMember(dest => dest.AppointmentDateTime, opt => opt.MapFrom(src => src.StartAt));

        CreateMap<Slot, SlotResponseDto>()
            .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments.Where(a => a.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)));
    }
}
