using System.Globalization;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Presentation.Helpers.Format;

public static class FormatCheck
{
    public static bool IsDateValid(string birthDate,out DateOnly returnDate)
    {
        var isValid=DateOnly.TryParseExact(birthDate, "yyyy-MM-dd",CultureInfo.InvariantCulture,DateTimeStyles.None,out var dt);

        returnDate = dt;
        return isValid;
    }   
    
    public static bool IsEmailValid(string email)
    {
        return User.EmailRegex.IsMatch(email);
    }
    
    public static bool IsGenderValid(string gender,out GenderEnum genderEnum)
    {
        var isValid=Enum.TryParse<GenderEnum>(gender, true, out var gd);
        genderEnum=gd;
        return isValid;
    }
    
    public static bool IsNameValid(string name)
    {
        return User.NameRegex.IsMatch(name);
    }
    
    public static List<string> IsPasswordValid(string password)
    {
        var errors=new List<string>();
        
        if(password.Length<User.MinPasswordLength)
            errors.Add("[red]Lozinka mora biti duga bar 8 znakova[/]");

        if (!User.PasswordUpperRegex.IsMatch(password))
            errors.Add("[red]Lozinka mora imati barem jedno veliko slovo[/]");
        
        if(!User.PasswordLowerRegex.IsMatch(password))
            errors.Add("[red]Loziknka mora imati barem jedno malo slovo[/]");

        if (!User.PasswordNoSpacesRegex.IsMatch(password))
            errors.Add("[red]Lozinka ne smije imati razmake[/]");

        if (!User.PasswordSpecialRegex.IsMatch(password))
            errors.Add("[red]Lozinka mora imati barem jedan specijalni znak[/]");

        return errors;
    }   
}