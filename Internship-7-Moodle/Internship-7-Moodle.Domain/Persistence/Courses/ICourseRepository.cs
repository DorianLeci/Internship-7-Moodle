using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Courses;

public interface ICourseRepository:IRepository<Course,int>
{
    Task<IEnumerable<CourseNotification>> GetAllCourseNotificationsAsync(int courseId);
    
    Task<IEnumerable<CourseMaterial>> GetAllCourseMaterialsAsync(int courseId);
    
    Task<IEnumerable<Course>> AddStudentAsync();
}