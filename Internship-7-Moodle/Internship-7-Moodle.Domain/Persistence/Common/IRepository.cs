using System.Linq.Expressions;
using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;

namespace Internship_7_Moodle.Domain.Persistence.Common;

public interface IRepository<TEntity,TId> where TEntity:BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>>? predicate=null,params Expression<Func<TEntity, object>>[] includeProperties);
    
    
    Task InsertAsync(TEntity entity);
    
    void Update(TEntity entity);
    
    Task DeleteAsync(TId id);
    
    void Delete(TEntity? entity);
    
    Task<TEntity?> GetByIdAsync(TId entityId);
    
    Task<TEntity?> GetByIdAsync(TId id,params Expression<Func<TEntity, object>>[] includeProperties);
}