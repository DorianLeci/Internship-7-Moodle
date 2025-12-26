using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories;

public class UserRepository:Repository<User,int>,IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
    {
        return await DbSet.AnyAsync(user => user.Email == email && (!excludeId.HasValue || user.Id != excludeId));       
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await DbSet.Include(u=>u.Role).FirstOrDefaultAsync(user => user.Email == email);
    }
}