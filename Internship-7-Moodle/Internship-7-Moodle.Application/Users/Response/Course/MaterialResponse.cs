namespace Internship_7_Moodle.Application.Users.Response.Course;

public class MaterialResponse
{
    public int MaterialId { get; set; }
    
    public string Title { get; set; }
    
    public string AuthorName { get; set; }
    
    public string Url { get; set; }

    public DateTime CreatedAt { get; set; }
}