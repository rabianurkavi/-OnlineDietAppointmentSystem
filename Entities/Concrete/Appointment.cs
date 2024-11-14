using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Appointment
{
    [Key] public int AppointmentID { get; set; }

    public int ClientID { get; set; }
    public int ConsultantID { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public bool Status { get; set; }
    public string Link { get; set; }//Admin için
    public string JoinID { get; set; }
    public string JoinUrl { get; set; }
    public string Password { get; set; }
    public string AppointmentStatus { get; set; }
    public bool PaymentStatus { get; set; }


    public virtual Client Client { get; set; }
    public virtual Consultant Consultant { get; set; }
}