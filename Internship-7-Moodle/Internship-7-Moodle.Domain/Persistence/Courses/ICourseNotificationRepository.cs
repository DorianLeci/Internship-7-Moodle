using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Persistence.Common;
using CourseNotification = Internship_7_Moodle.Domain.Entities.Courses.Notifications.CourseNotification;

namespace Internship_7_Moodle.Domain.Persistence.Courses;

public interface ICourseNotificationRepository:IRepository<CourseNotification,int>
{

}