using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

namespace Internship_7_Moodle.Domain.Entities.Courses.Notifications;

public partial class CourseNotification
{
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
        
        if(Subject?.Length>CourseNotification.SubjectMaxLength)
            validationResult.Add(EntityValidation.CourseValidation.MaxSubjectLength);  
    }

    private void CheckContent(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(Content))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(CourseNotification),"Sadržaj obavijesti"));
        
        if(Subject?.Length>CourseNotification.ContentMaxLength)
            validationResult.Add(EntityValidation.CourseValidation.MaxContentLength);          
    }
}