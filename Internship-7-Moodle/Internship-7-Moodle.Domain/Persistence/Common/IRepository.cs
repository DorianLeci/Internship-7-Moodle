using Internship_7_Moodle.Domain.Common.Model;

namespace Internship_7_Moodle.Domain.Persistence.Common;

public interface IRepository<TEntity,TId> where TEntity:class
{
    Task<GetAllResponse<TEntity>> GetAllAsync();
    
    Task InsertAsync(TEntity entity);
    
    void Update(TEntity entity);
    
    Task DeleteAsync(TId id);
    
    void Delete(TEntity? entity);
    
    Task<TEntity?> GetByIdAsync(int entityId);
}