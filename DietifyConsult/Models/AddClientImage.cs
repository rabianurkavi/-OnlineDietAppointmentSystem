namespace DietifyConsult.Models;

public class AddClientImage
{
    public int ClientID { get; set; }
    public string ClientName { get; set; }
    public string ClientSurName { get; set; }
    public DateTime ClientBirthDate { get; set; }
    public string ClientHeight { get; set; }
    public string ClientWeight { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPassword { get; set; }
    public IFormFile ClientImage { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreateDate { get; set; }
    public bool DietitianStatus { get; set; }
    public bool AdminStatus { get; set; }
}