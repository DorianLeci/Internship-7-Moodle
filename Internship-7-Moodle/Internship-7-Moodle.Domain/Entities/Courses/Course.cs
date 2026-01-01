using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.Courses;

public class Course:BaseEntity
{
    public const int MaxNameLength = 50;
    public const int MaxDescriptionLength = 200;
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public int Ects { get; set; }
    
    public int OwnerId { get; set; }
    public User Owner { get; set; } = null!;
    
    public ICollection<CourseUser> CourseStudents { get; set; }=new List<CourseUser>();
    
    public ICollection<Materials.CourseMaterial> Materials { get; set; }=new List<Materials.CourseMaterial>();
    public ICollection<Notifications.CourseNotification> Notifications { get; set; }=new List<Notifications.CourseNotification>();
}