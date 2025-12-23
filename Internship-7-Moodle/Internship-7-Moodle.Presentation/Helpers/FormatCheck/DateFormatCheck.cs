using System.Globalization;

namespace Internship_7_Moodle.Presentation.Helpers.FormatCheck;

public static class DateFormatCheck
{
    public static bool IsDateValid(string birthDate,out DateOnly returnDate)
    {
        var isValid=DateOnly.TryParseExact(birthDate, "yyyy-MM-dd",CultureInfo.InvariantCulture,DateTimeStyles.None,out var dt);

        returnDate = dt;
        return isValid;
    }   
}