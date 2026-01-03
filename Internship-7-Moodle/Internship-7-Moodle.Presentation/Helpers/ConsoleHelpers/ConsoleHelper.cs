using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;

public static class ConsoleHelper
{
    public static void SleepAndClear(string? message=null)
    {
        if(!string.IsNullOrEmpty(message))
            AnsiConsole.MarkupLine(message);
        
        Thread.Sleep(200);
        AnsiConsole.Clear();
    }

    public static void MenuChoiceSuccess(string? message=null)
    {
        AnsiConsole.Clear();
        
        if(!string.IsNullOrEmpty(message))
            AnsiConsole.MarkupLine(message);
        
        Thread.Sleep(500);
        AnsiConsole.Clear();

    }
    public static void SleepAndClear(int timeout,string? message=null)
    {
        if(message!=null)
            AnsiConsole.MarkupLine(message);
        
        Thread.Sleep(timeout);
        AnsiConsole.Clear();
    }
    
    public static async Task<bool> ShowCountdown(int remainingSeconds,int maxSeconds=30)
    {
        SleepAndClear();
        var cancelled = false;
        
        await AnsiConsole.Progress()
            .StartAsync(async ctx =>
            {
                var task = ctx.AddTask("[blue]Pričekajte...[/]", maxValue: maxSeconds);
                task.Value = maxSeconds-remainingSeconds;
                
                while (!ctx.IsFinished)
                {
                    task.Description = $"[blue]Pričekajte {maxSeconds-task.Value} s...[/]";
                    task.Increment(1);

                    if (Console.KeyAvailable)
                    {
                        var pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key is ConsoleKey.Escape or ConsoleKey.Q)
                        {
                            cancelled = true;
                            break;
                        }
                            
                    }
                    await Task.Delay(1000);
                }

            });
        return cancelled;
    }

    public static void ScreenExit(int timeout)
    {
        AnsiConsole.MarkupLine("\n[blue]Pritisni bilo koju tipku za izlaz...[/]");
        Console.ReadKey(true);  
        
        SleepAndClear(timeout,"[blue bold]\nIzlazak...[/]");
    }

    public static void AppExit(string message="[blue bold]Izlazak iz aplikacije...[/]")
    {
        if(!string.IsNullOrEmpty(message))
            AnsiConsole.MarkupLine(message);
        
        Thread.Sleep(2000);
    }
}