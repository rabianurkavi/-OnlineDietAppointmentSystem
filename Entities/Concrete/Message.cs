using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Message
{
    [Key] public int MessageID { get; set; }

    public int SenderID { get; set; }
    public int ReceiverID { get; set; }
    public string Subject { get; set; }
    public string MessageDetails { get; set; }
    public DateTime MessageDate { get; set; }
    public bool MessageStatus { get; set; }

    public Client SenderUser { get; set; }
    public Client ReceiverUser { get; set; }
}