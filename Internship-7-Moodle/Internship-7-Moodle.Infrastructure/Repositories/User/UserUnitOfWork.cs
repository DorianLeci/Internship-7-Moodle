using Internship_7_Moodle.Domain.Persistence.Messages;
using Internship_7_Moodle.Domain.Persistence.Roles;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Infrastructure.Database;

namespace Internship_7_Moodle.Infrastructure.Repositories.User;

public class UserUnitOfWork:IUserUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IUserRepository UserRepository { get; }
    public IRoleRepository RoleRepository { get; }
    
    public IMessageRepository MessageRepository { get; }

    public UserUnitOfWork(ApplicationDbContext context, IUserRepository userRepository, IRoleRepository roleRepository, IMessageRepository messageRepository)
    {
        _dbContext = context;
        UserRepository = userRepository;
        RoleRepository = roleRepository;
        MessageRepository = messageRepository;
    }
    public async Task CreateTransaction()
    {
        await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
        await _dbContext.Database.CommitTransactionAsync();
    }

    public async Task Rollback()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    
}