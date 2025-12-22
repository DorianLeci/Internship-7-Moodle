using Internship_7_Moodle.Presentation.Actions;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views;

public class MenuManager
{
    private readonly UserActions _userActions;

    public MenuManager(UserActions userActions)
    {
        _userActions = userActions;
    }
    public async Task RunAsync()
    {
        bool exitRequested = false;
        
        var menuActions = new Dictionary<string, Func<Task<bool>>>
        {
            ["Register"]=async() => {await HandleRegisterUserAsync(); return false; },
            ["Exit"]=async()=>{ Console.WriteLine("Exiting application..."); return true; }
        };

        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>().Title("[red]Main Menu[/]")
                    .AddChoices(menuActions.Keys));

            exitRequested = await menuActions[choice]();            
        }

    }

    public async Task HandleRegisterUserAsync()
    {
        Console.WriteLine("Pokrenut handle");
        await _userActions.RegisterUserAsync();
    }
}