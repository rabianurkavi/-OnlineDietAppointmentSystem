using Entities.Concrete;

namespace DietifyConsult.Models;

public class AddProfileImage
{
    public int ConsultantID { get; set; }
    public string ConsultantName { get; set; }
    public string ConsultantSurName { get; set; }
    public string ConsultantEmail { get; set; }
    public string ConsultantPassword { get; set; }
    public string ConsultantAddress { get; set; }
    public float RatingScore { get; set; }
    public string Specialization { get; set; }
    public IFormFile? ConsultantImage { get; set; }
    public string PhoneNumber { get; set; }
    public int Price { get; set; }

    public bool ConsultantStatus { get; set; }
    public int? ClientID { get; set; }

    public virtual Client Client { get; set; }
}