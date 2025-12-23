using System.Text.RegularExpressions;

namespace Internship_7_Moodle.Presentation.Helpers.FormatCheck;

public static class NameFormatCheck
{
    public static bool IsNameValid(string name)
    {
        var regex = new Regex(@"^\p{L}+$");
        return regex.IsMatch(name);
    }
}