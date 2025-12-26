using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views;

public class MainMenuManager
{
    private readonly UserActions _userActions;
    private readonly RoleEnum _roleName;
    
    public RoleEnum RoleName => _roleName;

    public MainMenuManager(UserActions userActions,RoleEnum roleName)
    {
        _userActions = userActions;
        _roleName = roleName;
    }

    public async Task RunAsync()
    {
        AnsiConsole.Clear();
        bool logoutRequested = false;

        var mainMenu = MenuBuilder.CreateMainMenu(this);

        while (!logoutRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Glavni izbornik[/]")
                    .AddChoices(mainMenu.Keys));

            logoutRequested = await mainMenu[choice]();            
        }
    }

    public async Task ShowCourseMenuAsync()
    {
        AnsiConsole.Clear();
    }
}