using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Presentation.Helpers.FormatCheck;

public static class GenderFormatCheck
{
    public static bool IsGenderValid(string gender,out GenderEnum genderEnum)
    {
        var isValid=Enum.TryParse<GenderEnum>(gender, true, out var gd);
        genderEnum=gd;
        return isValid;
    }
}