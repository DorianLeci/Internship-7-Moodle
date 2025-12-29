using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Helpers.FormatCheck;
using Internship_7_Moodle.Presentation.InputValidation;

namespace Internship_7_Moodle.Presentation.Helpers.PromptFunctions;

public static partial class PromptFunctions
{
    public static PresentationValidationResult<string> EmailCheck(string email)
    {
        return EmailFormatCheck.IsEmailValid(email)
            ? PresentationValidationResult<string>.Success(email)
            : PresentationValidationResult<string>.Error("[red]Email nije u ispravnom formatu[/]");
    }
    
    public static PresentationValidationResult<string> PasswordCheck(string password)
    {
        var errors=PasswordFormatCheck.IsPasswordValid(password);
                        
        return errors.Count==0 ? PresentationValidationResult<string>.Success(password) : PresentationValidationResult<string>.Error(string.Join("\n",errors));
    }
    public static PresentationValidationResult<string> ConfirmPasswordCheck(string confirmPassword,string password)
    {
        return string.Equals(confirmPassword,password) ? PresentationValidationResult<string>.Success(password) : PresentationValidationResult<string>.Error("Lozinke se ne podudaraju");
    }
    
    public static PresentationValidationResult<string> NameCheck(string name)
    {
        return NameFormatCheck.IsNameValid(name)
            ? PresentationValidationResult<string>.Success(name)
            : PresentationValidationResult<string>.Error(
                "[red]Ime nije u ispravnom formatu.Ne smije imati brojeve ili specijalne znakove[/]");
    }
    
    public static PresentationValidationResult<DateOnly?> BirthDateCheck(string birthDate)
    {
        return DateFormatCheck.IsDateValid(birthDate,out var dt)
            ? PresentationValidationResult<DateOnly?>.Success(dt)
            : PresentationValidationResult<DateOnly?>.Error("[red]Datum rođenja nije u ispravnom formatu[/]");

    }
    
    public static PresentationValidationResult<GenderEnum?> GenderCheck(string gender)
    {
        if (string.IsNullOrEmpty(gender))
            return PresentationValidationResult<GenderEnum?>.Success();

        return GenderFormatCheck.IsGenderValid(gender,out var gd)
            ? PresentationValidationResult<GenderEnum?>.Success(gd)
            : PresentationValidationResult<GenderEnum?>.Error("[red]Spol nije u ispravnom formatu[/]");
    }
}