using System.Text.RegularExpressions;
using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;
namespace Internship_7_Moodle.Domain.Entities.Courses.Materials;

public partial class CourseMaterial:BaseEntity
{
    public const int MaxTitleLength = 50;
    public const int MaxAuthorNameLength = 100;
    
    [GeneratedRegex(@"^[\p{L}]+( [\p{L}]+)*$")]
    private static partial Regex NameRegexGenerated();
    
    public static readonly Regex NameRegex = NameRegexGenerated();
    

    public string? Title { get; set; }

    public string? AuthorName { get; set; }
    
    public DateOnly? PublishedDate { get; set; }

    public string? Url { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    
    
    public Result<int> Create()
    {
        var result = Validate();
        return result.HasErrors ? Result<int>.Failure(result) : Result<int>.Success(Id);
    }
    

}