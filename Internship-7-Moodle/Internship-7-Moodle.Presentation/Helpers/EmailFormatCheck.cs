using System.Text.RegularExpressions;

namespace Internship_7_Moodle.Presentation.Helper;

public static class EmailFormatCheck
{
    public static bool IsEmailValid(string email)
    {
        var regex = new Regex(@"^[^@]{1,}@[^@]{2,}\.[^@]{3,}$");
        return regex.IsMatch(email);
    }
}