namespace Internship_7_Moodle.Domain.Common.Helper;

public static class DomainHelper
{
    public static bool? IsAdult(DateOnly? birthDate)
    {
        if (!birthDate.HasValue)
            return null;
        
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - birthDate.Value.Year;

        if (birthDate.Value > today.AddYears(-age))
            age--;

        return age >= 18;        
    }
}