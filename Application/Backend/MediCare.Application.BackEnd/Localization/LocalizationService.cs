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
        public string InvalidDoctorId => Reader.GetKeyValue("InvalidDoctorId", "Doctor ID must be greater than zero.");
        public string DoctorNotFound => Reader.GetKeyValue("DoctorNotFound", "Doctor was not found.");
        public string UserNotFound => Reader.GetKeyValue("UserNotFound", "User was not found.");
        public string UserAlreadyDoctor => Reader.GetKeyValue("UserAlreadyDoctor", "This user is already assigned to a doctor.");
        public string InvalidSpecialization => Reader.GetKeyValue("InvalidSpecialization", "Select a valid specialization.");
        public string SpecializationNotFound => Reader.GetKeyValue("SpecializationNotFound", "Selected specialization was not found.");
        public string InvalidConsultationFee => Reader.GetKeyValue("InvalidConsultationFee", "Consultation fee cannot be negative.");
        public string EnNameRequired => Reader.GetKeyValue("EnNameRequired", "English name is required.");
        public string EnDescriptionRequired => Reader.GetKeyValue("EnDescriptionRequired", "English description is required.");
   
    }
}
