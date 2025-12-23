using System.Text.RegularExpressions;

namespace Internship_7_Moodle.Presentation.Helpers.FormatCheck;

public static class PasswordFormatCheck
{
    public static List<string> IsPasswordValid(string password)
    {
        var errors=new List<string>();

        var upperCharRegex = new Regex("[A-Z]");
        var lowerCharRegex=new Regex("[a-z]");
        var spaceCharRegex = new Regex(@"^\S*$");
        var specialCharRegex = new Regex("[!@#$%^&*]");
            
        if(password.Length < 8)
            errors.Add("[red]Lozinka mora biti duga bar 8 znakova[/]");

        if (!upperCharRegex.IsMatch(password))
            errors.Add("[red]Lozinka mora imati barem jedno veliko slovo[/]");
        
        if(!lowerCharRegex.IsMatch(password))
            errors.Add("[red]Loziknka mora imati barem jedno malo slovo[/]");

        if (!spaceCharRegex.IsMatch(password))
            errors.Add("[red]Lozinka ne smije imati razmake[/]");

        if (!specialCharRegex.IsMatch(password))
            errors.Add("[red]Lozinka mora imati barem jedan specijalni znak[/]");

        return errors;
    }   
}