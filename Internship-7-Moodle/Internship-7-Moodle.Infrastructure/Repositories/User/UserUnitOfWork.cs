using Internship_7_Moodle.Domain.Persistence.Roles;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;

namespace Internship_7_Moodle.Infrastructure.Repositories.User;

public class UserUnitOfWork:UnitOfWork,IUserUnitOfWork
{
    public IUserRepository UserRepository { get; }
    
    public IRoleRepository RoleRepository { get; }

    public UserUnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository, IRoleRepository roleRepository)
        : base(dbContext)
    {
        UserRepository = userRepository;
        RoleRepository = roleRepository;
    }
    
}