using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Messages;

public interface IMessageRepository:IRepository<PrivateMessage,int>
{
    Task<IEnumerable<User>> GetUsersWithoutChatAsync(int currentUserId);
}