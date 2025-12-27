using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Persistence.Messages;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories.Message;

public class MessageRepository:Repository<PrivateMessage,int>,IMessageRepository
{
    public MessageRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Entities.Users.User>> GetUsersWithoutChatAsync(int currentUserId)
    {
        var chattedUserIdList = await DbSet
            .Where(m => m.SenderId == currentUserId || m.ReceiverId == currentUserId)
            .Select(m => m.SenderId == currentUserId ? m.ReceiverId : m.SenderId)
            .Distinct()
            .ToListAsync();
        
        var usersWithoutChat=await Context.Users
            .Where(u=>!chattedUserIdList.Contains(u.Id))
            .ToListAsync();
        
        return usersWithoutChat;
    }
}