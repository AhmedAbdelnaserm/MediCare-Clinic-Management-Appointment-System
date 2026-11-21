namespace MediCare.Application.BackEnd.Dto.ClinicDto
{
    public class WorkingHourDto
    {
        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
