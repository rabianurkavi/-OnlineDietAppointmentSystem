using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Notification
{
    [Key] public int NotificationID { get; set; }

    public string NotificationType { get; set; }
    public string NotificationTypeSymbol { get; set; }
    public string NotificationDetails { get; set; }
    public DateTime NotificationDate { get; set; }
    public bool NotificationStatus { get; set; }
    public string NotificationColor { get; set; }

    public int AdminID { get; set; }
    public virtual Admin Admin { get; set; }
}