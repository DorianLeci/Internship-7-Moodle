namespace Internship_7_Moodle.Domain.Common.Helper;

public static class DateTimeProvider
{
    private static DateTime Now=>DateTime.Now;
    
    public static DateTime StarOfToday=>Now.Date;
    
    public static DateTime EndOfToday=>Now.Date.AddDays(1);
    
    public static DateTime StartOfMonth=>new DateTime(Now.Year,Now.Month,1);

    public static DateTime EndOfMonth => StartOfMonth.AddMonths(1);
}