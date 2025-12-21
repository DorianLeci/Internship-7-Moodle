namespace Internship_7_Moodle.Domain.Persistence.Common;

public interface IUnitOfWork
{
    Task CreateTransaction();
    Task Commit();
    Task Rollback();
    Task SaveAsync();   
}