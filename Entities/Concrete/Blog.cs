﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Blog
{
    [Key] public int BlogID { get; set; }

    public int ConsultantID { get; set; }
    public string BlogTitle { get; set; }
    public string BlogDescription { get; set; }
    public string BlogImage { get; set; }
    public float BlogScore { get; set; }
    public bool Status { get; set; }
    public DateTime BlogCreateDate { get; set; }

    public virtual Consultant Consultant { get; set; }
    public List<BlogComment> BlogComments { get; set; }
}