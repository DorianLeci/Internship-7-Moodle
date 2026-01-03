using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.Common;

public static class MenuRunner
{
    public const string SuccessMsg="[rgb(0,200,0) bold]Uspješan odabir[/]";
    public const string ExitChoiceConst = "Izlazak iz izbornika";
    public const string AppExit="Izlazak iz aplikacije";
    
    public static async Task RunMenuAsync(Dictionary<string, Func<Task<bool>>> menuOptions, string title,
        string successMessage=SuccessMsg,string exitChoice=ExitChoiceConst)
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
    
    public static async Task RunMenuAsync(Dictionary<string, Func<Task<bool>>> menuOptions)
    {
        
        var appExitRequested = false;
    
        while (!appExitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow bold] Početni izbornik[/]")
                    .AddChoices(menuOptions.Keys));
            
            var exitRequested = await menuOptions[choice]();

            if (!exitRequested) continue;
            
            appExitRequested = await ChoiceMenu.ShowChoiceMenuAsync(("Da", true), ("Ne", false),
                "[yellow] Želiš li zaista izaći iz aplikacije[/]");
            
            AnsiConsole.Clear();

        }
    }
        
}