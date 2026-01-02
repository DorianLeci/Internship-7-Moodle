using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Helpers.Format;
using Internship_7_Moodle.Presentation.InputValidation;

namespace Internship_7_Moodle.Presentation.Helpers.PromptFunctions;

public static partial class PromptFunctions
{
    public static class UserRegister
    {
    public static PresentationValidationResult<string> EmailCheck(string email)
    {
        return FormatCheck.IsEmailValid(email)
            ? PresentationValidationResult<string>.Success(email)
            : PresentationValidationResult<string>.Error("[red]\nEmail nije u ispravnom formatu[/]");
    }
    
    public static PresentationValidationResult<string> PasswordCheck(string password)
    {
        var errors=FormatCheck.IsPasswordValid(password);
                        
        return errors.Count==0 ? PresentationValidationResult<string>.Success(password) : PresentationValidationResult<string>.Error("\n"+string.Join("\n",errors));
    }
    public static PresentationValidationResult<string> ConfirmPasswordCheck(string confirmPassword,string password)
    {
        return string.Equals(confirmPassword,password) ? PresentationValidationResult<string>.Success(password) : PresentationValidationResult<string>.Error("[red]\nLozinke se ne podudaraju[/]");
    }
    
    public static PresentationValidationResult<string> NameCheck(string name)
    {
        var formattedName = name.FormatInput();
        
        return FormatCheck.IsNameValid(formattedName)
            ? PresentationValidationResult<string>.Success(formattedName)
            : PresentationValidationResult<string>.Error(
                "[red]\nIme nije u ispravnom formatu.Ne smije imati brojeve ili specijalne znakove[/]");
    }
    
    public static PresentationValidationResult<DateOnly?> BirthDateCheck(string birthDate)
    {
        if (!FormatCheck.IsDateValid(birthDate,out var dt))
            return PresentationValidationResult<DateOnly?>.Error("[red]\nDatum rođenja nije u ispravnom formatu[/]");

        var errors = new List<string>();
        
        if (DomainHelper.IsAdult(dt) == false)
            errors.Add("[red]\nKorisnik mora biti punoljetan[/]");
        
        if (DomainHelper.IsTooOld(dt) == true)
            errors.Add($"[red]\nKorisnik ne smije biti stariji od {User.MaxAge} godina[/]");
        
        return errors.Count != 0
            ? PresentationValidationResult<DateOnly?>.Error(string.Join("\n",errors))
            : PresentationValidationResult<DateOnly?>.Success(dt);
    }
    
    public static PresentationValidationResult<GenderEnum?> GenderCheck(string gender)
    {
        if (string.IsNullOrEmpty(gender))
            return PresentationValidationResult<GenderEnum?>.Success();

        return FormatCheck.IsGenderValid(gender,out var gd)
            ? PresentationValidationResult<GenderEnum?>.Success(gd)
            : PresentationValidationResult<GenderEnum?>.Error("[red]\nSpol nije u ispravnom formatu[/]");
    }
}        
    }
