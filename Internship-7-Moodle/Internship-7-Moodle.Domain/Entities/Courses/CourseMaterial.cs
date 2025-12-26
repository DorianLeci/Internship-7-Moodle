using Internship_7_Moodle.Domain.Common.Abstractions;

namespace Internship_7_Moodle.Domain.Entities.Courses;

public class CourseMaterial:BaseEntity
{
    public const int MaxTitleLength = 50;
    public const int MaxAuthorNameLength = 100;
    
    public string Title { get; set; }
    
    public string AuthorName { get; set; }
    
    public DateOnly? PublishedDate { get; set; }
    
    public string Url { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
}