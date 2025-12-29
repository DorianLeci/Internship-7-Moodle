using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Chats;

public interface IChatRepository:IRepository<Chat,int>
{
    Task<Chat?> GetChatAsync(int userAId, int userBId);
}