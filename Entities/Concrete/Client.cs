using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Client
{
    [Key] public int ClientID { get; set; }

    public string ClientName { get; set; }
    public string ClientSurName { get; set; }
    public DateTime ClientBirthDate { get; set; }
    public string ClientHeight { get; set; }
    public string ClientWeight { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPassword { get; set; }
    public string? ClientImage { get; set; }
    public string? PhoneNumber { get; set; }
    public bool DietitianStatus { get; set; }
    public bool AdminStatus { get; set; }
    public DateTime CreateDate { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Consultant> Consultants { get; set; }
    public ICollection<Admin> Admins { get; set; }
    public ICollection<Message> SenderMessage { get; set; }
    public ICollection<Message> ReceiverMessage { get; set; }
}