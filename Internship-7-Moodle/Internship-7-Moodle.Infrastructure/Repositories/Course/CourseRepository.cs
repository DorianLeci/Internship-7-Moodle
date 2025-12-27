using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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
}