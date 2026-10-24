namespace MediCare.Application.Identity.Localization
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
        #endregion

        #region Tarabezty Identity
        string EmailOrUserNameAlreadyExist { get; }
        string EmailOrPasswordIsIncorrect { get; }
        string RegisterSuccessfully { get; }
        string LoginSuccessfully { get; }

        #endregion
    }
}
