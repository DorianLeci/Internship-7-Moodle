using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Roles;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories;

public class RoleRepository:Repository<Role,int>,IRoleRepository
{
    public RoleRepository(DbContext context) : base(context)
    {
    }

    public Task<Role?> GetByRoleEnumAsync(RoleEnum role)
    {
        return DbSet.SingleOrDefaultAsync(r => r.RoleName== role);
    }
}