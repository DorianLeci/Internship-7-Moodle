using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.PivotTables;

public class CourseUser:BaseEntity
{
    public int UserId { get; set; }
    public int CourseId { get; set; }

    public User User { get; set; } = null!;
    public Course Course { get; set; } = null!;

}