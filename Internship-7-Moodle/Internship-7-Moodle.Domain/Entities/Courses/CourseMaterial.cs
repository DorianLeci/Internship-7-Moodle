using Internship_7_Moodle.Domain.Abstractions;

namespace Internship_7_Moodle.Domain.Entities.Courses;

public class CourseMaterial:BaseEntity
{
    public string Name { get; set; }
    
    public string Url { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
}