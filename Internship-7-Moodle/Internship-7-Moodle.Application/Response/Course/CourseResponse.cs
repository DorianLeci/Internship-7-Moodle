namespace Internship_7_Moodle.Application.Response.Course;

public class CourseResponse
{
    public int CourseId { get; init; }

    public string CourseName { get; init; } = null!;

    public string CourseDescription { get; set; } = null!;
    
    public int Ects{get;init;}
    
    public string? ProfessorName { get; init; }
    
}