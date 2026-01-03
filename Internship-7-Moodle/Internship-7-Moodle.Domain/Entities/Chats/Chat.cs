using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.Chats;

public class Chat:BaseEntity
{
    public int UserAId { get; set; }
    
    public int UserBId { get; set; }

    public User UserA { get; set; } = null!;
    public User UserB { get; set; } = null!;
    
    public ICollection<PrivateMessage>  PrivateMessages { get; set; }=new List<PrivateMessage>();
    
}