using Internship_7_Moodle.Domain.Abstractions;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.PivotTables;

public class CourseUser:BaseEntity
{
    public int UserId { get; set; }
    public int CourseId { get; set; }
    
    public User User { get; set; }
    public Course Course { get; set; }
    
}