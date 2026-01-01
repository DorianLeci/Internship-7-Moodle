using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;

namespace Internship_7_Moodle.Infrastructure.Repositories.Course;

public class CourseUserRepository:Repository<CourseUser,int>,ICourseUserRepository
{
    public CourseUserRepository(ApplicationDbContext context) : base(context)
    {
    }
}