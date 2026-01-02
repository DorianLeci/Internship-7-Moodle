namespace Internship_7_Moodle.Application.Response.Course;

public class MaterialResponse
{
    public int MaterialId { get; set; }

    public string Title { get; init; } = null!;

    public string AuthorName { get; init; } = null!;

    public string Url { get; init; } = null!;

    public DateTime CreatedAt { get; init; }
}