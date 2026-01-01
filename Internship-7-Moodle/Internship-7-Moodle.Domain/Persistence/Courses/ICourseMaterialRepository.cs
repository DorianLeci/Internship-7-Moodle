using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Persistence.Common;
using CourseMaterial = Internship_7_Moodle.Domain.Entities.Courses.Materials.CourseMaterial;

namespace Internship_7_Moodle.Domain.Persistence.Courses;

public interface ICourseMaterialRepository:IRepository<CourseMaterial,int>
{
    
}