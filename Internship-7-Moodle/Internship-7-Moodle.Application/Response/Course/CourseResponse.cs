namespace Internship_7_Moodle.Application.Response.Course;

public class CourseResponse
{
    public int CourseId { get; set; }
    
    public string CourseName { get; set; }
    
    public string CourseDescription { get; set; }
    
    public int Ects{get;set;}
    
    public string? ProfessorName { get; set; }
    
}