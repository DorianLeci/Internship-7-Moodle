using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;
using CourseNotification = Internship_7_Moodle.Domain.Entities.Courses.Notifications.CourseNotification;

namespace Internship_7_Moodle.Infrastructure.Repositories.Course;

public class CourseNotificationRepository:Repository<CourseNotification,int>,ICourseNotificationRepository
{
    public CourseNotificationRepository(ApplicationDbContext context) : base(context)
    {
    }
}