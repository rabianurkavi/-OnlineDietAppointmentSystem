using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Consultant
{
    [Key]
    public int ConsultantID { get; set; }
    public string ConsultantName { get; set; }
    public string ConsultantSurName { get; set; }
    public string ConsultantEmail { get; set; }
    public string ConsultantPassword { get; set; }
    public string ConsultantAddress { get; set; }
    public float RatingScore { get; set; }
    public string Specialization { get; set; }
    public string ConsultantImage { get; set; }
    public string PhoneNumber { get; set; }
    public int Price { get; set; }

    public bool ConsultantStatus { get; set; }
    public int? ClientID { get; set; }

    public virtual Client Client { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Blog> Blogs { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Education> Educations { get; set; }
    public ICollection<WorkExperience> WorkExperiences { get; set; }
}