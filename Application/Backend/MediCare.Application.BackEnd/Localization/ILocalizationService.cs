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
        #endregion

    }
}
