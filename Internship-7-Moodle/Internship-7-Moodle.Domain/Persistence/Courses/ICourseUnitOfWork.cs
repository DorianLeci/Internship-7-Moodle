using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Courses;

public interface ICourseUnitOfWork:IUnitOfWork
{
    ICourseRepository CourseRepository { get; }
    
    ICourseNotificationRepository CourseNotificationRepository { get; }
    
    ICourseMaterialRepository CourseMaterialRepository { get; }
    
    ICourseUserRepository CourseUserRepository { get; }
}