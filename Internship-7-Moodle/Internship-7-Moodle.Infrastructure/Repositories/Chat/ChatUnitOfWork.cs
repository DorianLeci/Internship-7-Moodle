using Internship_7_Moodle.Domain.Persistence.Chats;
using Internship_7_Moodle.Domain.Persistence.Messages;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;

namespace Internship_7_Moodle.Infrastructure.Repositories.Chat;

public class ChatUnitOfWork:UnitOfWork,IChatUnitOfWork
{
    public IChatRepository ChatRepository { get; }
    public IMessageRepository MessageRepository { get; }

    public ChatUnitOfWork(ApplicationDbContext dbContext,IChatRepository chatRepository,IMessageRepository messageRepository) : base(dbContext)
    {
       ChatRepository=chatRepository;
       MessageRepository=messageRepository; 
    }


}