using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

namespace Internship_7_Moodle.Domain.Entities.Courses;

public class CourseMaterial:BaseEntity
{
    public const int MaxTitleLength = 50;
    public const int MaxAuthorNameLength = 100;

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
    
    private ValidationResult Validate()
    {
        var validationResult = new ValidationResult();
        
        CheckTitle(validationResult);
        
        CheckAuthorName(validationResult);
        
        CheckPublishedDate(validationResult);
        
        return validationResult;
    }

    private void CheckTitle(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(Title))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(CourseMaterial),"Naslov materijala"));
        
        if(Title?.Length>MaxTitleLength)
            validationResult.Add(EntityValidation.CourseValidation.MaxTitleLength);  
    }

    private void CheckAuthorName(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(AuthorName))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(CourseMaterial),"Ime autora"));
        
        if(AuthorName?.Length>MaxAuthorNameLength)
            validationResult.Add(EntityValidation.CourseValidation.MaxAuthorNameLength);          
    }

    private void CheckPublishedDate(ValidationResult validationResult)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        
        if(PublishedDate!=null && PublishedDate>today)
            validationResult.Add(EntityValidation.CourseValidation.PublishedDateTooNew);
    }

    private void CheckUrl(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(Url))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(CourseMaterial),"Url"));
            return;
        }
        
        if (!Uri.TryCreate(Url, UriKind.Absolute, out var uriResult))
            validationResult.Add(EntityValidation.CourseValidation.InvalidUrl);
    }
}