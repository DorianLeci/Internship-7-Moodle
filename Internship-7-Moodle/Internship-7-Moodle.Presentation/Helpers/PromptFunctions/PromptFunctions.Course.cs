using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Presentation.InputValidation;

namespace Internship_7_Moodle.Presentation.Helpers.PromptFunctions;

public static partial class PromptFunctions
{
    public static class Course
    {
        public static PresentationValidationResult<string> ContentCheck(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return PresentationValidationResult<string>.Error("[red]\nSadržaj obavijesti ne može biti prazan.[/]");
            
            return text.Length<=CourseNotification.ContentMaxLength
                ? PresentationValidationResult<string>.Success(text)
                : PresentationValidationResult<string>.Error($"[red]\nSadržaj obavijesti ne smije imati više od {CourseNotification.ContentMaxLength} znakova[/]");
        }        
        
        public static PresentationValidationResult<string> SubjectCheck(string text)
        {
            return text.Length<=CourseNotification.SubjectMaxLength
                ? PresentationValidationResult<string>.Success(text)
                : PresentationValidationResult<string>.Error($"[red]\nNaslov obavijesti ne smije imati više od {CourseNotification.SubjectMaxLength} znakova[/]");
        }    
    }

}