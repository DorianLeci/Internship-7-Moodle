using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Courses.Materials;
using Internship_7_Moodle.Presentation.Helpers.Format;
using Internship_7_Moodle.Presentation.InputValidation;
using CourseNotification = Internship_7_Moodle.Domain.Entities.Courses.Notifications.CourseNotification;

namespace Internship_7_Moodle.Presentation.Helpers.PromptFunctions;

public static partial class PromptFunctions
{
    public static class Course
    {
        public static PresentationValidationResult<string> ContentCheck(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return PresentationValidationResult<string>.Error("[red]\nSadržaj obavijesti ne može biti prazan.[/]");

            return text.Length <= CourseNotification.ContentMaxLength
                ? PresentationValidationResult<string>.Success(text)
                : PresentationValidationResult<string>.Error(
                    $"[red]\nSadržaj obavijesti ne smije imati više od {CourseNotification.ContentMaxLength} znakova[/]");
        }

        public static PresentationValidationResult<string> SubjectCheck(string text)
        {
            return text.Length <= CourseNotification.SubjectMaxLength
                ? PresentationValidationResult<string>.Success(text)
                : PresentationValidationResult<string>.Error($"[red]\nNaslov obavijesti ne smije imati više od {CourseNotification.SubjectMaxLength} znakova[/]");
        }

        public static PresentationValidationResult<string> TitleCheck(string title)
        {
            return title.Length <= CourseMaterial.MaxTitleLength
                ? PresentationValidationResult<string>.Success(title)
                : PresentationValidationResult<string>.Error($"[red]\nNaslov knjige ne smije imati više od {CourseMaterial.MaxTitleLength} znakova[/]");
        }

        public static PresentationValidationResult<string> AuthorNameCheck(string authorName)
        {
            var authorNameFormatted=FormatAuthorName.FormatInput(authorName);
            
            if (authorNameFormatted.Length > CourseMaterial.MaxAuthorNameLength)
                return PresentationValidationResult<string>.Error(
                    $"[red]\nNaslov knjige ne smije imati više od {CourseMaterial.MaxTitleLength} znakova[/]");

            return FormatCheck.IsAuthorNameValid(authorNameFormatted)
                ? PresentationValidationResult<string>.Success(authorNameFormatted)
                : PresentationValidationResult<string>.Error(
                    $"[red]\nIme autora ne smije imati brojeve i specijalne znakove[/]");
        }

        public static PresentationValidationResult<DateOnly?> PublishedDateCheck(string? publishedDate)
        {
            if (string.IsNullOrWhiteSpace(publishedDate))
                return PresentationValidationResult<DateOnly?>.Success(null);

            if (!FormatCheck.IsDateValid(publishedDate, out var dt))
                return PresentationValidationResult<DateOnly?>.Error(
                    "[red]Datum objavljivanja nije u ispravnom formatu[/]");

            var today = DateOnly.FromDateTime(DateTime.Now);

            return dt > today
                ? PresentationValidationResult<DateOnly?>.Error(
                    "[red]Datum objavljivanja ne smije biti noviji od današnjeg[/]")
                : PresentationValidationResult<DateOnly?>.Success(dt);
        }
        
        public static PresentationValidationResult<string> UrlCheck(string url)
        {
            return FormatCheck.IsUrlValid(url) 
                ? PresentationValidationResult<string>.Success(url)
                :PresentationValidationResult<string>.Error("[red]\nUrl je neispravnog formata[/]");
                
        }

    }

}