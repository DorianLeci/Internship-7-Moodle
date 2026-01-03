using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Entities.Courses.Materials;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using CourseNotification = Internship_7_Moodle.Domain.Entities.Courses.Notifications.CourseNotification;

namespace Internship_7_Moodle.Infrastructure.Repositories.Course;

public class CourseRepository:Repository<Domain.Entities.Courses.Course,int>,ICourseRepository
{
    public CourseRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CourseNotification>> GetAllCourseNotificationsAsync(int courseId)
    {
        return await Context.CourseNotifications
            .Where(c => c.CourseId == courseId)
            .Include(c => c.Course).ThenInclude(c=>c.Owner)
            .OrderByDescending(c=>c.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseMaterial>> GetAllCourseMaterialsAsync(int courseId)
    {
        return await Context.CourseMaterials
            .Where(c => c.CourseId == courseId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Domain.Entities.Users.User>> GetAllStudentsEnrolledAsync(int courseId)
    {
        return await Context.CourseUsers
            .Where(cu => cu.CourseId == courseId)
            .Select(cu => cu.User)
            .OrderBy(u=>u.FirstName)
            .ThenBy(u=>u.LastName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Domain.Entities.Users.User>> GetAllStudentsNotEnrolledAsync(int courseId)
    {
        var enrolledStudentIdList=await Context.CourseUsers
            .Where(cu => cu.CourseId == courseId)
            .Select(cu => cu.UserId)
            .ToListAsync();
        
        return await Context.Users
            .Include(u => u.Role)
            .Where(u=>u.Role.RoleName==RoleEnum.Student && !enrolledStudentIdList.Contains(u.Id))
            .OrderBy(u=>u.FirstName)
            .ThenBy(u=>u.LastName)
            .ToListAsync();
    }

    public Task<int> GetCourseCountAsync(PeriodEnum period)
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
        
        return  filteredQuery.CountAsync();
    }

    public async Task<IEnumerable<(int CourseId, string CourseName, int StudentCount)>> GetTopCoursesByStudentCountAsync(PeriodEnum period)
    {
        var query = Context.CourseUsers.AsQueryable();
        
        var filteredQuery = period switch
        {
            PeriodEnum.Today => query.Where(cu =>
                cu.CreatedAt >= DateTimeProvider.StarOfToday && cu.CreatedAt < DateTimeProvider.EndOfToday),
            PeriodEnum.ThisMonth => query.Where(cu =>
                cu.CreatedAt >= DateTimeProvider.StartOfMonth && cu.CreatedAt < DateTimeProvider.EndOfMonth),
            _ => query
        };

        var result = await filteredQuery
            .GroupBy(cu => new { cu.CourseId, cu.Course.Name })
            .Select(g => new
            {
                g.Key.CourseId,
                CourseName = g.Key.Name,
                StudentCount = g.Count()
            })
            .OrderByDescending(x => x.StudentCount)
            .ThenBy(x => x.CourseName)
            .Take(3)
            .ToListAsync();

        return result.Select(x => (x.CourseId, x.CourseName, x.StudentCount));
        
        
    }
}