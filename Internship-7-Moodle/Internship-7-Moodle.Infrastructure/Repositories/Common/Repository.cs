using System.Linq.Expressions;
using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Common;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories.Common;

public class Repository<TEntity,TId>:IRepository<TEntity,TId> where TEntity :BaseEntity
{
    protected readonly ApplicationDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(ApplicationDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity,bool>>? predicate=null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy=null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query= DbSet.AsQueryable();

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        
        if(predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            query = orderBy(query);
        
        return await query.ToListAsync();
    }

    public async Task InsertAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public async Task DeleteAsync(TId id)
    {
        var entity=await DbSet.FindAsync(id);
        if(entity!=null)
            DbSet.Remove(entity);
    }

    public void Delete(TEntity? entity)
    {
        if(entity!=null)
            DbSet.Remove(entity);
    }

    public async Task<TEntity?> GetByIdAsync(TId entityId)
    {
        return await DbSet.FindAsync(entityId);
    }

    public async Task<TEntity?> GetByIdAsync(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = DbSet.AsQueryable();
        
        query = includeProperties.Aggregate(query, (current, include) => current.Include(include));

        return await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }
}
