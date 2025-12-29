using Internship_7_Moodle.Domain.Persistence.Chats;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories.Chat;

public class ChatRepository:Repository<Domain.Entities.Chats.Chat,int>,IChatRepository
{
    public ChatRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Domain.Entities.Chats.Chat?> GetChatAsync(int userAId, int userBId)
    {
        return await DbSet
            .Include(c => c.PrivateMessages)
                .ThenInclude(pm => pm.Sender)
            .Include(c => c.PrivateMessages)
                .ThenInclude(pm => pm.Receiver)
            .Include(c => c.UserA)
            .Include(c => c.UserB)
            .FirstOrDefaultAsync(c => c.UserAId == userAId && c.UserBId == userBId);
    }
}