using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.UiState;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.Common;

public class ChatFeature
{
    private readonly int _userId;
    
    private readonly ChatActions _chatActions;

    public ChatFeature(ChatActions chatActions,int userId)
    {
        _chatActions = chatActions;
        _userId = userId;
    }
    
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
                ? await _chatActions.GetAllUsersWithoutChatAsync(_userId, roleFilter)
                : await _chatActions.GetAllUsersWithChatAsync(_userId, roleFilter);
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
        const int maxVisibleMsg = 5;
        
        ConsoleHelper.ClearAndSleep();
        var result = await _chatActions.GetChatAsync(_userId, otherUserId);
        if (result.IsFailure || result.Value == null)
        {
            Writer.Chat.ChatErrorWriter(result);
            ConsoleHelper.ClearAndSleep(2000, "[blue]Izlazak...[/]");
            return;
        }

        var state = new ChatUiState(result.Value,_chatActions)
        {
            MaxVisibleMessages = maxVisibleMsg,
            ScrollOffset = result.Value.Messages.Count-maxVisibleMsg
        };
        
        await Writer.Chat.RunChatLive(state);

        ConsoleHelper.SleepAndClear(2000);
    }
}