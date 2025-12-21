using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.Courses;

public class CourseNotification:BaseEntity
{
    public string Subject { get; set; }
    
    public string Content { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public string CreatorId { get; set; }
    public User Creator { get; set; }
}