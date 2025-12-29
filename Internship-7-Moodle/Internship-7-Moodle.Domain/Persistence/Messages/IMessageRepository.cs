using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Messages;

public interface IMessageRepository:IRepository<PrivateMessage,int>
{
    Task<IEnumerable<User>> GetUsersWithoutChatAsync(int currentUserId,RoleEnum? roleFilter=null);
    
    Task<IEnumerable<User>> GetUsersWithChatAsync(int currentUserId,RoleEnum? roleFilter=null);

    Task MarkMessagesAsReadAsync(List<int> messageIdList);

    Task<List<PrivateMessage>> GetPrivateMessagesAsync(IEnumerable<int> messageIdList);
}