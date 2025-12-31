using Internship_7_Moodle.Domain.Persistence.Common;
using Internship_7_Moodle.Domain.Persistence.Messages;

namespace Internship_7_Moodle.Domain.Persistence.Chats;

public interface IChatUnitOfWork:IUnitOfWork
{
  IChatRepository ChatRepository { get; }
  IMessageRepository MessageRepository { get; }
}