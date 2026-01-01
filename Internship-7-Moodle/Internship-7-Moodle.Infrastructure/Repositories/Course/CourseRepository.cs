using Internship_7_Moodle.Domain.Entities.Courses;
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
            .OrderByDescending(cu=>cu.CreatedAt)
            .Select(cu => cu.User)
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
            .OrderByDescending(cu=>cu.CreatedAt)
            .ToListAsync();
    }
    
}