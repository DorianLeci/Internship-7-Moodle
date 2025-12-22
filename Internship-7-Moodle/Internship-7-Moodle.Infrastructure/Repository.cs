using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Internship_7_Moodle.Infrastructure;

public class Repository<TEntity,TId>:IRepository<TEntity,TId> where TEntity : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(DbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }
    
    public async Task<GetAllResponse<TEntity>> GetAllAsync()
    {
        var entityList=await DbSet.ToListAsync();
        return new GetAllResponse<TEntity>(entityList);
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

    public async Task<TEntity?> GetByIdAsync(int entityId)
    {
        return await DbSet.FindAsync(entityId);
    }
}
