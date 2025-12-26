namespace Internship_7_Moodle.Application.Users.Response.User;

public class StudentCourseResponse
{
    public int CourseId { get; set; }
    
    public string CourseName { get; set; }
    
    public string CourseDescription { get; set; }
    
    public int Ects{get;set;}
    
    public string ProfessorName { get; set; }
    
}