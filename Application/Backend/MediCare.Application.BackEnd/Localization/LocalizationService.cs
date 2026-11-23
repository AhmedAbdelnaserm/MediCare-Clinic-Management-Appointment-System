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
        public string DoctorProfileNotFound => Reader.GetKeyValue("DoctorProfileNotFound", "Doctor profile was not found.");
        public string SpecializationRequired => Reader.GetKeyValue("SpecializationRequired", "Select a valid specialization.");
        public string DoctorDescriptionRequired => Reader.GetKeyValue("DoctorDescriptionRequired", "Professional description is required.");
        public string InvalidProfileImage => Reader.GetKeyValue("InvalidProfileImage", "Choose a JPG, PNG, or WebP image up to 5 MB.");
        public string DoctorProfileUpdated => Reader.GetKeyValue("DoctorProfileUpdated", "Professional profile saved.");
        public string DoctorClinicsLoaded => Reader.GetKeyValue("DoctorClinicsLoaded", "Clinic assignments loaded.");
        public string ScheduleOverlapError => Reader.GetKeyValue("ScheduleOverlapError", "These working hours overlap with this doctor's schedule at another clinic.");
        public string ClinicAdminNotFound => Reader.GetKeyValue("ClinicAdminNotFound", "Clinic admin was not found.");
        public string ConsultationDurationInvalid => Reader.GetKeyValue("ConsultationDurationInvalid", "Consultation duration must be greater than zero.");
        public string DoctorAlreadyAssigned => Reader.GetKeyValue("DoctorAlreadyAssigned", "This doctor is already assigned to your clinic.");
        public string WorkingHoursRequired => Reader.GetKeyValue("WorkingHoursRequired", "At least one working hour is required.");
        public string WorkingHourDayInvalid => Reader.GetKeyValue("WorkingHourDayInvalid", "Invalid day of week.");
        public string WorkingHourOrderInvalid => Reader.GetKeyValue("WorkingHourOrderInvalid", "Working hour start time must be before end time.");
        public string WorkingHoursOverlap => Reader.GetKeyValue("WorkingHoursOverlap", "Working hours cannot overlap on the same day.");
   
        public string ClinicNameRequired => Reader.GetKeyValue("ClinicNameRequired", "Clinic name is required");
        public string ClinicAddressRequired => Reader.GetKeyValue("ClinicAddressRequired", "Clinic address is required");
        public string AreaRequired => Reader.GetKeyValue("ClinicAreaRequired", "Please select a valid area");
        public string AreaNotFound => Reader.GetKeyValue("AreaNotFound", "The selected area does not exist");
        public string ClinicNotFound => Reader.GetKeyValue("ClinicNotFound", "The requested clinic does not exist");
    }
}
