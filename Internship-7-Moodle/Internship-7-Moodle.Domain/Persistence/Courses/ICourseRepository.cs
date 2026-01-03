using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Common;
using CourseMaterial = Internship_7_Moodle.Domain.Entities.Courses.Materials.CourseMaterial;
using CourseNotification = Internship_7_Moodle.Domain.Entities.Courses.Notifications.CourseNotification;

namespace Internship_7_Moodle.Domain.Persistence.Courses;

public interface ICourseRepository:IRepository<Course,int>
{
    Task<IEnumerable<CourseNotification>> GetAllCourseNotificationsAsync(int courseId);
    
    Task<IEnumerable<CourseMaterial>> GetAllCourseMaterialsAsync(int courseId);
    
    Task<IEnumerable<User>> GetAllStudentsEnrolledAsync(int courseId);
    
    Task<IEnumerable<User>> GetAllStudentsNotEnrolledAsync(int courseId);
    
    Task<int> GetCourseCountAsync(PeriodEnum period);
    
    Task<IEnumerable<(int CourseId,string CourseName,int StudentCount)>> GetTopCoursesByStudentCountAsync(PeriodEnum period);
    
}