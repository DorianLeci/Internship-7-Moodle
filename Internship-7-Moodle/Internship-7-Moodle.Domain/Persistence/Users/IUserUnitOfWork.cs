using Internship_7_Moodle.Domain.Persistence.Chats;
using Internship_7_Moodle.Domain.Persistence.Common;
using Internship_7_Moodle.Domain.Persistence.Messages;
using Internship_7_Moodle.Domain.Persistence.Roles;

namespace Internship_7_Moodle.Domain.Persistence.Users;

public interface IUserUnitOfWork:IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
}