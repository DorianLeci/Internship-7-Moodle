using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Chats;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;
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
            .FirstOrDefaultAsync(c => 
                (c.UserAId == userAId && c.UserBId == userBId) ||
                (c.UserAId == userBId && c.UserBId == userAId)
            );
    }

    public async Task<IEnumerable<Domain.Entities.Users.User>> GetUsersWithChatAsync(int currentUserId, RoleEnum? roleFilter = null)
    {
        var chats = await DbSet
            .Where(c => c.UserAId == currentUserId || c.UserBId == currentUserId)
            .Include(c => c.UserA)
                .ThenInclude(u => u.Role)
            .Include(c => c.UserB)
                .ThenInclude(u => u.Role)
            .Include(c => c.PrivateMessages)
            .ToListAsync();

        var usersWithLastMessage = chats
            .Select(c => new
            {
                User = c.UserAId==currentUserId ? c.UserB:c.UserA,
                LastMessageAt=c.PrivateMessages.Max(m=>m.CreatedAt)
            });
        
        if(roleFilter.HasValue)
            usersWithLastMessage = usersWithLastMessage.Where(u => u.User.Role.RoleName == roleFilter.Value);

        return usersWithLastMessage
            .OrderByDescending(x => x.LastMessageAt)
            .Select(x => x.User);
    }

    public async Task<IEnumerable<Domain.Entities.Users.User>> GetUsersWithoutChatAsync(int currentUserId, RoleEnum? roleFilter = null)
    {
        var chattedUserIds = await DbSet
            .Where(c => c.UserAId == currentUserId || c.UserBId == currentUserId)
            .Select(c => c.UserAId == currentUserId ? c.UserBId : c.UserAId)
            .ToListAsync();

        var query = Context.Users
            .Include(u => u.Role)
            .Where(u => u.Id != currentUserId && !chattedUserIds.Contains(u.Id));
        
        if(roleFilter.HasValue)
            query = query.Where(u => u.Role.RoleName == roleFilter.Value);
        
        return await query
            .OrderBy(u=>u.Id).
            ToListAsync();
    }
}