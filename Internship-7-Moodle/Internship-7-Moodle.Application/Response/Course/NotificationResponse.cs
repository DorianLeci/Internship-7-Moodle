namespace Internship_7_Moodle.Application.Response.Course;

public class NotificationResponse
{
    public int NotificationId { get; set; }

    public string Subject { get; init; } = null!;

    public string Content { get; init; } = null!;
    
    public string? ProfessorName{get;init;}
    
    public DateTime CreatedAt { get; init; }
    
}