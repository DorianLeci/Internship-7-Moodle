using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Repositories.User;

public class UserRepository:Repository<Domain.Entities.Users.User,int>,IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
    {
        return await DbSet.AnyAsync(user => user.Email == email && (!excludeId.HasValue || user.Id != excludeId));       
    }

    public async Task<Domain.Entities.Users.User?> GetUserByEmailAsync(string email)
    {
        return await DbSet.Include(u=>u.Role).FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<IEnumerable<Domain.Entities.Courses.Course>> GetAllStudentCoursesAsync(int studentId)
    {
        return await Context.CourseUsers
            .Where(cu => cu.UserId == studentId)
            .Include(cu => cu.Course).ThenInclude(c=>c.Owner)
            .Select(cu => cu.Course)
            .OrderByDescending(c=>c.Ects)
            .ThenBy(c=>c.Name)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Domain.Entities.Courses.Course>> GetAllProfessorCoursesAsync(int professorId)
    {
        return await Context.Courses
            .Where(c => c.OwnerId == professorId)
            .OrderByDescending(c=>c.Ects)
            .ThenBy(c=>c.Name)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Domain.Entities.Users.User>> GetAllStudentsAsync()
    {
        return await DbSet
            .Include(u=>u.Role)
            .Where(u=>u.Role.RoleName==RoleEnum.Student)
            .OrderBy(u=>u.LastName)
            .ThenBy(u=>u.FirstName)
            .ToListAsync();
    }

    public async Task<IEnumerable<(RoleEnum Role, int Count)>> GetUserCountGroupedByRole(PeriodEnum period)
    {
        var query = DbSet.AsQueryable();

        var filteredQuery = period switch
        {
            PeriodEnum.Today => query.Where(u =>
                u.CreatedAt >= DateTimeProvider.StarOfToday && u.CreatedAt < DateTimeProvider.EndOfToday),
            PeriodEnum.ThisMonth => query.Where(u =>
                u.CreatedAt >= DateTimeProvider.StartOfMonth && u.CreatedAt < DateTimeProvider.EndOfMonth),
            _ => query
        };
                
        var result= await filteredQuery
            .GroupBy(u => u.Role.RoleName)
            .ToListAsync();

        return result.Select(g =>(g.Key, g.Count()))
            .OrderByDescending(g=>g.Item2).ThenBy(g=>g.Key);
    }
}