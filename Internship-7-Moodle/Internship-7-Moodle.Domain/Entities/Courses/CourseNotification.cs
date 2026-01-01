using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.Courses;

public class CourseNotification:BaseEntity
{
    public const int SubjectMaxLength = 100;
    public const int ContentMaxLength = 300;
    public string? Subject { get; set; }

    public string? Content { get; set; }
    
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
        
        CheckSubject(validationResult);
        
        CheckContent(validationResult);
        
        return validationResult;
    }

    private void CheckSubject(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(Subject))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(CourseNotification),"Naslov obavijesti"));
        
        if(Subject?.Length>SubjectMaxLength)
            validationResult.Add(EntityValidation.CourseValidation.MaxSubjectLength);  
    }

    private void CheckContent(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(Content))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(CourseNotification),"Sadržaj obavijesti"));
        
        if(Subject?.Length>ContentMaxLength)
            validationResult.Add(EntityValidation.CourseValidation.MaxContentLength);          
    }
    
}