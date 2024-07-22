using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int ClientID { get; set; }
        public int ConsultantID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public bool Status { get; set; }
        public string Link { get; set; }

        public virtual Client Client { get; set; }
        public virtual Consultant Consultant { get; set; }
    }
}
