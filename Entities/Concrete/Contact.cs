using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Contact
{
    [Key] public int ContactId { get; set; }

    public string ContactNameSurName { get; set; }
    public string ContactMail { get; set; }
    public string ContactSubject { get; set; }
    public string ContactMessage { get; set; }
    public DateTime MessageDate { get; set; }
}