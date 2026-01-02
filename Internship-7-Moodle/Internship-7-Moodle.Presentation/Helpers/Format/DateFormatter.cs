namespace Internship_7_Moodle.Presentation.Helpers.Format;

public static class DateFormatter
{
    private const string DisplayFormat = "dd.MM.yyyy HH:mm";

    public static string ToDisplayString(this DateTime date)
    {
        return date.ToString(DisplayFormat);
    }
}