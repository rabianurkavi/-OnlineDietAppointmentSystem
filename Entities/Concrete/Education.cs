using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }
        public int ConsultantID { get; set; }
        public string EducationLevel { get; set; }
        public string UniversityName { get; set; }
        public DateTime UniversityGraduateHistory  { get; set; }
        public DateTime UniversityEndDate { get; set; }

        public virtual Consultant Consultant { get; set; }
    }
}
