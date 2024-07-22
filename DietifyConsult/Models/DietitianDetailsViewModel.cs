using Entities.Concrete;

namespace DietifyConsult.Models
{
    public class DietitianDetailsViewModel
    {
        public Consultant Consultant { get; set; }
        public Dictionary<DateTime, List<TimeSpan>> AvailableTimesByDay { get; set; }
        public DateTime? SelectedDate { get; set; }
    }
}
