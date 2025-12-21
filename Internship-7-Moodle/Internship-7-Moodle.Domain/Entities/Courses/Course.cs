using Internship_7_Moodle.Domain.Abstractions;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.Courses;

public class Course:BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Ects { get; set; }
    
    public int OwnerId { get; set; }
    public User Owner { get; set; }
    
    public ICollection<CourseUser> CourseStudents { get; set; }
}