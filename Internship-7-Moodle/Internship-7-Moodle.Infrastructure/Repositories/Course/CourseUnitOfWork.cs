using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Internship_7_Moodle.Infrastructure.Repositories.Course;

public class CourseUnitOfWork:ICourseUnitOfWork
{
    public ICourseRepository CourseRepository { get; }
    private readonly ApplicationDbContext _dbContext;

    public CourseUnitOfWork(ICourseRepository courseRepository, ApplicationDbContext dbContext)
    {
        CourseRepository = courseRepository;
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