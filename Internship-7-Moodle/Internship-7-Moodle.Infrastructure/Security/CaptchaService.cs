namespace Internship_7_Moodle.Infrastructure.Security;

public static class CaptchaService
{
    private static string _currentCaptcha = null!;
    private const int CaptchaLength = 6;
    private static readonly Random Random = new();

    public static string GenerateCaptcha()
    {
        const string letters = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz";
        const string digits = "0123456789";
        const string combination=letters + digits;

        var captchaChars = new List<char>()
        {
            letters[Random.Next(letters.Length)],
            digits[Random.Next(digits.Length)]
        };
        
        while(captchaChars.Count < CaptchaLength)
            captchaChars.Add(combination[Random.Next(combination.Length)]);
        
        _currentCaptcha = new string(captchaChars.OrderBy(_=>Random.Next()).ToArray());
        return _currentCaptcha;
    }

    public static bool IsCaptchaValid(string userCaptcha)
    {
        return string.IsNullOrEmpty(userCaptcha) || string.Equals(userCaptcha, _currentCaptcha);
    }
}