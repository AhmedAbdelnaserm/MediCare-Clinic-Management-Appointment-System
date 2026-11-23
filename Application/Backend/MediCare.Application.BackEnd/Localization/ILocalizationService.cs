namespace MediCare.Application.BackEnd.Localization
{
    public interface ILocalizationService
    {
        #region System
        string GeneralError { get; }
        string NoDataFound { get; }
        string GeneralSuccess { get; }
        string InvalidRequest { get; }
        string DataRequired { get; }
        string InvalidData { get; }
        string InvalidDoctorId { get; }
        string DoctorNotFound { get; }
        string UserNotFound { get; }
        string UserAlreadyDoctor { get; }
        string InvalidSpecialization { get; }
        string SpecializationNotFound { get; }
        string InvalidConsultationFee { get; }
        string EnNameRequired { get; }
        string EnDescriptionRequired { get; }
        string DoctorProfileNotFound { get; }
        string SpecializationRequired { get; }
        string DoctorDescriptionRequired { get; }
        string InvalidProfileImage { get; }
        string DoctorProfileUpdated { get; }
        string DoctorClinicsLoaded { get; }
        string ScheduleOverlapError { get; }
        string ClinicAdminNotFound { get; }
        string ConsultationDurationInvalid { get; }
        string DoctorAlreadyAssigned { get; }
        string WorkingHoursRequired { get; }
        string WorkingHourDayInvalid { get; }
        string WorkingHourOrderInvalid { get; }
        string WorkingHoursOverlap { get; }
        #endregion
        #region Clinic
        string ClinicNameRequired { get; }
        string ClinicAddressRequired { get; }
        string AreaRequired { get; }
        string AreaNotFound { get; }
        string ClinicNotFound { get; }
        #endregion
    }
}
