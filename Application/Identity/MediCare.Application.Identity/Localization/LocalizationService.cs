namespace MediCare.Application.Identity.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly LocalizationFileReader.LocalizationFileReader Reader;
        public LocalizationService()
        {
            Reader = new LocalizationFileReader.LocalizationFileReader(
                "localization.common",
                "localization.identity"
            );
        }

        #region General System
        public string GeneralError => Reader.GetKeyValue("GeneralError", "An error has occurred please try again");
        public string GeneralSuccess => Reader.GetKeyValue("GeneralSuccess", "Success");
        public string NoDataFound => Reader.GetKeyValue("NoDataFound", "No Data Found");
        public string InvalidRequest => Reader.GetKeyValue("InvalidRequest", "Invalid Request");
        public string DataRequired => Reader.GetKeyValue("DataRequired", "Data Required");
        public string InvalidData => Reader.GetKeyValue("InvalidData", "Invalid Data");
        #endregion

        #region MediCare Identity
        public string EmailOrUserNameAlreadyExist => Reader.GetKeyValue("EmailOrUserNameAlreadyExist", "Email Or User Name Already Exist");
        public string EmailOrPasswordIsIncorrect => Reader.GetKeyValue("EmailOrPasswordIsIncorrect", "Email Or Password Is Incorrect");
        public string RegisterSuccessfully => Reader.GetKeyValue("RegisterSuccessfully", "Register Successfully");
        public string LoginSuccessfully => Reader.GetKeyValue("LoginSuccessfully", "Login Successfully");

        #endregion
    }
}
