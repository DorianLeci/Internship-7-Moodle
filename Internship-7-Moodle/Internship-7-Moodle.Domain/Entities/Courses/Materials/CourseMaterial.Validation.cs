using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

namespace Internship_7_Moodle.Domain.Entities.Courses.Materials;

public partial class CourseMaterial
{
    private ValidationResult Validate()
    {
        var validationResult = new ValidationResult();
        
        CheckTitle(validationResult);
        
        CheckAuthorName(validationResult);
        
        CheckPublishedDate(validationResult);
        
        CheckUrl(validationResult);
        
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
        if (string.IsNullOrWhiteSpace(AuthorName))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(CourseMaterial),"Ime autora"));
            return;
        }
        
        if(AuthorName.Length>MaxAuthorNameLength)
            validationResult.Add(EntityValidation.CourseValidation.MaxAuthorNameLength);

        if (!NameRegex.IsMatch(AuthorName))
            validationResult.Add(EntityValidation.CourseValidation.AuthorNameInvalid);
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