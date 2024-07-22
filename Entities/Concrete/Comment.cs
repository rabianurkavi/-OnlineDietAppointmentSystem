using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int ClientID { get; set; }
        public int ConsultantID { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public float ConsultantScore { get; set; }
        public string CommentDescription { get; set; }
        public bool CommentStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual Consultant Consultant { get; set; }
    }
}
