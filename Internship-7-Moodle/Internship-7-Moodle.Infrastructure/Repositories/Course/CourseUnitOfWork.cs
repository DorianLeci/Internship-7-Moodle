using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;

namespace Internship_7_Moodle.Infrastructure.Repositories.Course;

public class CourseUnitOfWork:UnitOfWork,ICourseUnitOfWork
{
    public ICourseRepository CourseRepository { get; }
    
    public ICourseNotificationRepository CourseNotificationRepository { get; }
    
    public ICourseMaterialRepository CourseMaterialRepository { get; }

    public CourseUnitOfWork(ICourseRepository courseRepository, ApplicationDbContext dbContext, ICourseNotificationRepository courseNotificationRepository, ICourseMaterialRepository courseMaterialRepository) : base(dbContext)
    {
        CourseRepository = courseRepository;
        CourseNotificationRepository = courseNotificationRepository;
        CourseMaterialRepository = courseMaterialRepository;
    }
    
    
}