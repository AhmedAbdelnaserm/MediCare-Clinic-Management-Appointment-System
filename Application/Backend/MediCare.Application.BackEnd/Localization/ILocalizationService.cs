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
        #endregion

    }
}
