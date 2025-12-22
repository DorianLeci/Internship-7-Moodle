using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories;

public class UserRepository:Repository<User,int>,IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
    {
        return await DbSet.AnyAsync(user => user.Email == email && (!excludeId.HasValue || user.Id != excludeId));       
    }
}