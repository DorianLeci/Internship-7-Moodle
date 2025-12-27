using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.Messages;

public class PrivateMessage:BaseEntity
{
    public const int MaxTextLength = 1000;
    public string Text { get; set; }
    public bool IsRead { get; set; }
    
    public int SenderId { get; set; }
    public User Sender { get; set; }
    
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
}