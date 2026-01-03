namespace Internship_7_Moodle.Application.Response.Course;

public class TopCourseResponse
{
    public int CourseId { get; init; }

    public string CourseName { get; init; } = null!;
    
    public int EnrollmentCount { get; init; }
}