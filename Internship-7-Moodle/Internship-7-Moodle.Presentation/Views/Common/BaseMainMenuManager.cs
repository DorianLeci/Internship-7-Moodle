using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.PromptFunctions;
using Internship_7_Moodle.Presentation.Helpers.PromptHelpers;
using Internship_7_Moodle.Presentation.Helpers.UiState;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Spectre.Console;


namespace Internship_7_Moodle.Presentation.Views.Common;

public abstract class BaseMainMenuManager
{
    protected readonly UserActions UserActions;
    protected readonly int UserId;

    public int Id => UserId;

    protected BaseMainMenuManager(UserActions userActions, int userId)
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

    public async Task ShowConversationMenuAsync(bool withoutChat, string title)
    {
        ConsoleHelper.ClearAndSleep();

        var exitRequested = false;
        var newMsgMenu = MenuBuilder.MenuBuilder.CreateConversationMenu(this, withoutChat, title);

        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .AddChoices(newMsgMenu.Keys));

            exitRequested = await newMsgMenu[choice]();
        }
    }

    public async Task ShowUsersToChatWithAsync(bool withoutChat, string title, RoleEnum? roleFilter = null)
    {
        var exitRequested = false;

        while (!exitRequested)
        {
            var users = withoutChat
                ? await UserActions.GetAllUsersWithoutChatAsync(UserId, roleFilter)
                : await UserActions.GetAllUsersWithChatAsync(UserId, roleFilter);
            var userList = users.ToList();

            var usrChatMenu = MenuBuilder.MenuBuilder.CreateUsersToChatWithMenu(this, userList);

            if (userList.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]Nema dostupnih korisnika[/]");
                ConsoleHelper.ClearAndSleep(1000);
                return;
            }

            var prompt = new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText("[grey](Stisni strelicu prema dolje da vidiš više)[/]")
                .EnableSearch()
                .SearchPlaceholderText("Upiši tekst da pretražuješ")
                .AddChoices(usrChatMenu.Keys);

            prompt.SearchHighlightStyle = new Style().Background(ConsoleColor.DarkBlue);

            var choice = AnsiConsole.Prompt(prompt);

            exitRequested = await usrChatMenu[choice]();
        }


    }

    public async Task OpenPrivateChatAsync(int otherUserId)
    {
        ConsoleHelper.ClearAndSleep();
        var result = await UserActions.GetChatAsync(UserId, otherUserId);
        if (result.IsFailure || result.Value == null)
        {
            Writer.Chat.ChatErrorWriter(result);
            ConsoleHelper.ClearAndSleep(2000, "[blue]Izlazak...[/]");
            return;
        }

        var state = new ChatUiState(result.Value,UserActions);
        
        await Writer.Chat.RunChatLive(state,UserActions);

        ConsoleHelper.SleepAndClear(2000);
    }
    
}
    