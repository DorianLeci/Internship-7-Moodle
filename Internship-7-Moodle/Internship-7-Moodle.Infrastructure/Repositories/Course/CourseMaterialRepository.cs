using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories.Common;

namespace Internship_7_Moodle.Infrastructure.Repositories.Course;

public class CourseMaterialRepository:Repository<CourseMaterial,int>,ICourseMaterialRepository
{
    public CourseMaterialRepository(ApplicationDbContext context) : base(context)
    {
    }
}