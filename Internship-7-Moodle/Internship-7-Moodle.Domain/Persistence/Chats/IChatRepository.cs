using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Chats;

public interface IChatRepository:IRepository<Chat,int>
{
    Task<Chat?> GetChatAsync(int userAId, int userBId);
    
    Task<IEnumerable<User>> GetUsersWithChatAsync(int currentUserId, RoleEnum? roleFilter = null);
    
    Task<IEnumerable<User>> GetUsersWithoutChatAsync(int currentUserId, RoleEnum? roleFilter = null);
    
    Task<IEnumerable<(int UserId,string FullName,int MsgCount)>> GetTopUsersByMsgSent(PeriodEnum period);
}