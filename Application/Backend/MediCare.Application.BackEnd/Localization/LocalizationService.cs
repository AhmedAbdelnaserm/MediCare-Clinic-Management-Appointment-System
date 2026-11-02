namespace MediCare.Application.BackEnd.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly LocalizationFileReader.LocalizationFileReader Reader;
        public LocalizationService()
        {
            Reader = new LocalizationFileReader.LocalizationFileReader(
                "localization.common",
                "localization.backend"
            );
        }
        public string GeneralError => Reader.GetKeyValue("GeneralError", "An error has occurred please try again");
        public string GeneralSuccess => Reader.GetKeyValue("GeneralSuccess", "Success");
        public string NoDataFound => Reader.GetKeyValue("NoDataFound", "No Data Found");
        public string InvalidRequest => Reader.GetKeyValue("InvalidRequest", "Invalid Request");
        public string DataRequired => Reader.GetKeyValue("DataRequired", "Data Required");
        public string InvalidData => Reader.GetKeyValue("InvalidData", "Invalid Data");
    }
}
