using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkExperience
    {
        [Key]
        public int WorkExperienceID { get; set; }
        public int ConsultantID { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Continues { get; set; }

		public virtual Consultant Consultant { get; set; }
    }
}
