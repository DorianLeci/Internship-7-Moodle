using Internship_7_Moodle.Domain.Persistence.Common;
using Internship_7_Moodle.Infrastructure.Database;

namespace Internship_7_Moodle.Infrastructure.Repositories.Common;

public class UnitOfWork:IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    protected UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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