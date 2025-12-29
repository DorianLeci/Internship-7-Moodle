using FluentValidation.Validators;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Messages;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories.Message;

public class MessageRepository:Repository<PrivateMessage,int>,IMessageRepository
{
    public MessageRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Entities.Users.User>> GetUsersWithoutChatAsync(int currentUserId,RoleEnum? roleFilter=null)
    {
        var chattedUserIdList = await DbSet
            .Where(m => m.SenderId == currentUserId || m.ReceiverId == currentUserId)
            .Select(m => m.SenderId == currentUserId ? m.ReceiverId : m.SenderId)
            .Distinct()
            .ToListAsync();

        var usersWithoutChat = Context.Users
            .Where(u => !chattedUserIdList.Contains(u.Id) && u.Id != currentUserId)
            .Include(u=>u.Role)
            .OrderBy(u=>u.Id);


        return (roleFilter.HasValue)
            ? await usersWithoutChat.Where(u => u.Role.RoleName==roleFilter).ToListAsync()
            : await usersWithoutChat.ToListAsync();
    }

    public async Task<IEnumerable<Domain.Entities.Users.User>> GetUsersWithChatAsync(int currentUserId, RoleEnum? roleFilter = null)
    {
        var chattedUsersQuery = DbSet
            .Where(pm => pm.SenderId == currentUserId || pm.ReceiverId == currentUserId)
            .GroupBy(pm => pm.SenderId == currentUserId ? pm.ReceiverId : pm.SenderId)
            .Select(g => new
            {
                UserId = g.Key,
                LastMessageAt = g.Max(x => x.CreatedAt)
            })

            .Join(
                Context.Users.Include(u => u.Role),
                g => g.UserId,
                user => user.Id,
                (g, user) => new
                {
                    User = user,
                    LastMessageAt = g.LastMessageAt
                }
            )
            .OrderByDescending(x => x.LastMessageAt)
            .Select(x => x.User);
        
        return (roleFilter.HasValue)
            ? await chattedUsersQuery.Where(u => u.Role.RoleName==roleFilter).ToListAsync()
            : await chattedUsersQuery.ToListAsync();
        
    }

    public async Task MarkMessagesAsReadAsync(List<int> messageIdList)
    {
        await DbSet
            .Where(m => messageIdList.Contains(m.Id))
            .ExecuteUpdateAsync(s=>s.SetProperty(m=>m.IsRead,true));
    }
    public async Task<List<PrivateMessage>> GetPrivateMessagesAsync(IEnumerable<int> messageIdList)
    {
        return await DbSet
            .Where(m => messageIdList.Contains(m.Id))
            .ToListAsync();
    }
}