using Internship_7_Moodle.Domain.Enumerations;
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
        ConsoleHelper.ClearAndSleep();
        
        var exitRequested = false;
        var newMsgMenu = MenuBuilder.MenuBuilder.CreateNewMessageMenu(this);
        
        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Nova poruka[/]")
                    .AddChoices(newMsgMenu.Keys));

            exitRequested = await newMsgMenu[choice]();     
        }        
    }

    public async Task ShowUsersWithoutChatAsync(RoleEnum? roleFilter=null)
    {
        var users = await UserActions.GetAllUsersWithoutChatAsync(UserId, roleFilter);
        var userList = users.ToList();
        
        if (userList.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]Nema dostupnih korisnika[/]");
            ConsoleHelper.ClearAndSleep(1000);
            return;
        }
        
        
        var exitRequested = false;
        var usrChatMenu = MenuBuilder.MenuBuilder.CreateUsersWithoutChatMenu(this, userList);
        
        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Dostupni korisnici[/]")
                    .AddChoices(usrChatMenu.Keys));

            exitRequested = await usrChatMenu[choice]();     
        }        
        

    }

    public async Task OpenPrivateChatAsync(int userId)
    {
        AnsiConsole.Write("Privatni chaat");
        ConsoleHelper.ClearAndSleep(3000);
    }

}