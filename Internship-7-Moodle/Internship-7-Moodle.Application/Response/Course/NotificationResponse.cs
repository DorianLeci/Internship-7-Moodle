namespace Internship_7_Moodle.Application.Response.Course;

public class NotificationResponse
{
    public int NotificationId { get; set; }
    
    public string Subject { get; set; }
    
    public string Content { get; set; }
    
    public string ProfessorName{get;set;}
    
    public DateTime CreatedAt { get; set; }
    
}