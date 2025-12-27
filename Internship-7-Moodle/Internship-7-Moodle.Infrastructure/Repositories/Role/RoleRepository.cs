using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Roles;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories.Role;

public class RoleRepository:Repository<Domain.Entities.Roles.Role,int>,IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task<Domain.Entities.Roles.Role?> GetByRoleEnumAsync(RoleEnum role)
    {
        return DbSet.SingleOrDefaultAsync(r => r.RoleName== role);
    }
}