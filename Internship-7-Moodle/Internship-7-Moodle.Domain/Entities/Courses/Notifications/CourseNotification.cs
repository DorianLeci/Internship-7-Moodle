using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;

namespace Internship_7_Moodle.Domain.Entities.Courses.Notifications;

public partial class CourseNotification:BaseEntity
{
    public const int SubjectMaxLength = 100;
    public const int ContentMaxLength = 300;
    public string? Subject { get; set; }

    public string? Content { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    
    public Result<int> Create()
    {
        var result = Validate();
        return result.HasErrors ? Result<int>.Failure(result) : Result<int>.Success(Id);
    }
    

    
}