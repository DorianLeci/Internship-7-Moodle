using System.Text;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.InputValidation;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.Reader;

public static class MultilineReader
{
    public static async Task<PresentationValidationResult<T>> ReadMultilineInput<T>(Func<Task<bool>> showExitMenu,string message, Func<string, PresentationValidationResult<T>> validationFunc)
    {
        var lines= new StringBuilder();
        
        while (true)
        {
            ConsoleHelper.SleepAndClear();
            AnsiConsole.MarkupLine($"[bold]{message}[/]");
            AnsiConsole.MarkupLine("[grey]Unesi multiline tekst. END = kraj unosa[/]");

            while (true)
            {
                var line=Console.ReadLine();

                if (line == null) break;

                if (line.Trim().Equals("END", StringComparison.OrdinalIgnoreCase))
                {
                    if(lines.Length > 0 && lines[^1]=='\n')
                        lines.Remove(lines.Length - 1, 1);
                    break;
                }
                
                lines.AppendLine(line);
            }
            var input=lines.ToString();
            
            var result = validationFunc(input);
            
            if (result.Successful)
            {
                return result;
            }
            
            AnsiConsole.MarkupLine(result.Message ?? "[red]Neispravan unos[/]");
            
            var isExitChosen=await showExitMenu();
            if (isExitChosen)
                return PresentationValidationResult<T>.Cancelled();
            
            lines.Clear();
        }

    }
}