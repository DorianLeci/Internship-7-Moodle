using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.Common;

public abstract class BaseMainMenuManager
{
    protected readonly UserActions UserActions;
    protected readonly int UserId;
    
    public int Id => UserId;

    protected BaseMainMenuManager(UserActions userActions,int userId)
    {
        UserActions = userActions;
        UserId = userId;
    }

    public abstract Task RunAsync();

    public async Task ShowPrivateChatMenuAsync()
    {
        ConsoleHelper.ClearAndSleep();
        
        var exitRequested = false;
        var chatMenu = MenuBuilder.MenuBuilder.CreatePrivateChatMenu(this);
        
        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Privatni chat[/]")
                    .AddChoices(chatMenu.Keys));

            exitRequested = await chatMenu[choice]();     
        }
    }

    public async Task ShowNewMessageMenuAsync()
    {
        
    }

}