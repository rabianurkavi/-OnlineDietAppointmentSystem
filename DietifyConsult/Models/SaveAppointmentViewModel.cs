namespace DietifyConsult.Models
{
    public class SaveAppointmentViewModel
    {
        public int ConsultantID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan SelectedTime { get; set; }
    }
}
