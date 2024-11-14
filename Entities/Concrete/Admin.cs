using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Admin
{
    [Key] public int AdminID { get; set; }

    public string AdminFirstName { get; set; }
    public string AdminLastName { get; set; }
    public string AdminEmail { get; set; }
    public int ClientID { get; set; }
    public string AdminPassword { get; set; }
    public string AdminPhoneNumber { get; set; }
    public DateTime CreateDateTime { get; set; }
    public int RoleID { get; set; }

    public virtual Client Client { get; set; }
    public virtual Role Role { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}