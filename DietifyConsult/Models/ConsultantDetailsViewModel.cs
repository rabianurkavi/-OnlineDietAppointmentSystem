using Entities.Concrete;

namespace DietifyConsult.Models;

public class ConsultantDetailsViewModel
{
    public int ConsultantID { get; set; }
    public string ConsultantName { get; set; }
    public string ConsultantSurName { get; set; }
    public string ConsultantEmail { get; set; }
    public string ConsultantAddress { get; set; }
    public string RatingScore { get; set; }
    public string Specialization { get; set; }
    public string ConsultantImage { get; set; }
    public string PhoneNumber { get; set; }
    public List<Education> Educations { get; set; }
    public List<WorkExperience> WorkExperiences { get; set; }
}