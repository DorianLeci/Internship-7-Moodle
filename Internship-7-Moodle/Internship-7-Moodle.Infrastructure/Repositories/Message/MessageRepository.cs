using FluentValidation.Validators;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Messages;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories.Message;

public class MessageRepository:Repository<PrivateMessage,int>,IMessageRepository
{
    public MessageRepository(ApplicationDbContext context) : base(context)
    {
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