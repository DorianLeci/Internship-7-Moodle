using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Service;

public class AntiBotService
{
    private const int CooldownSeconds = 30;
    private DateTime? _lastFailedLogin;
    
    public async Task<bool> ApplyCooldownAsync()
    {
        if (!_lastFailedLogin.HasValue) return false;
        
        var cooldownEnd=_lastFailedLogin.Value.AddSeconds(CooldownSeconds);
            
        var remaining=(int)(cooldownEnd-DateTime.Now).TotalSeconds;

        if (remaining<=0)
            return false;
            
        var cancelled= await ConsoleHelper.ShowCountdown(remaining);
        AnsiConsole.Clear();
            
        return cancelled;

    }

    public void RecordFailedLogin()
    {
        _lastFailedLogin = DateTime.Now;
    }
}