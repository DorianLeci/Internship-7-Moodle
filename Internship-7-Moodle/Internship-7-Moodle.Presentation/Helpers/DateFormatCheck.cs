using System.Globalization;

namespace Internship_7_Moodle.Presentation.Helpers;

public static class DateFormatCheck
{
    public static bool IsDateValid(string birthDate)
    {
        
        return DateOnly.TryParseExact(birthDate, "yyyy-MM-dd",CultureInfo.InvariantCulture,DateTimeStyles.None,out _);
    }   
}