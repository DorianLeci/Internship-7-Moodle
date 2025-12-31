using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.Common;

public static class MenuRunner
{
    public static async Task RunMenuAsync(Dictionary<string, Func<Task<bool>>> menuOptions, string title,
        string successMessage ="[green]Uspješan odabir[/]",string exitChoice="Izlazak iz izbornika")
    {
        
        var exitRequested = false;

        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .AddChoices(menuOptions.Keys));
            
            if(choice!=exitChoice)
                ConsoleHelper.MenuChoiceSuccess(successMessage);
            
            exitRequested = await menuOptions[choice]();     
        }
    }
        
}