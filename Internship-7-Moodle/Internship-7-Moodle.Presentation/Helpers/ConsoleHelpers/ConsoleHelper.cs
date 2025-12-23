using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;

public static class ConsoleHelper
{
    public static void ClearAndSleep(string? message=null)
    {
        if(message!=null)
            AnsiConsole.MarkupLine(message);
        
        Thread.Sleep(1000);
        AnsiConsole.Clear();
    }   
}