using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Roles;

public interface IRoleRepository:IRepository<Role,int>
{
    Task<Role?> GetByRoleEnumAsync(RoleEnum role);
}