using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.PromptFunctions;
using Internship_7_Moodle.Presentation.Helpers.PromptHelpers;
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
        const int panelHeight = 15;

        var result = await UserActions.GetChatAsync(UserId, otherUserId);
        if (result.IsFailure || result.Value == null)
        {
            Writer.Chat.ChatErrorWriter(result);
            ConsoleHelper.ClearAndSleep(2000, "[blue]Izlazak...[/]");
            return;
        }

        var chatResponse = result.Value;
        string? lastError = null;

        var exitChat = false;
        while (!exitChat)
        {           
            
            await Writer.Chat.ChatWriter(chatResponse, UserActions);

            lastError=await LiveErrorMessage(lastError);
            
            var keyInfo = Console.ReadKey(intercept: true);
            
            var refreshResult = await UserActions.GetChatAsync(UserId, otherUserId);
            if (!refreshResult.IsFailure && refreshResult.Value != null)
                chatResponse = refreshResult.Value;

            switch (keyInfo.Key)
            {
                
                case ConsoleKey.Q:
                case ConsoleKey.Escape:
                    exitChat = true;
                    ConsoleHelper.ClearAndSleep(1500, "[blue]\nIzlazak...[/]");
                    break;
            }
        }
    }

    private static async Task<string?> LiveErrorMessage(string? lastError)
    {
        const int waitingSeconds = 10;
        
        var statusLive = AnsiConsole.Live(new Markup("\n[blue]Enter = poruka | ↑↓ scroll | Q/Esc = izlaz[/])"))
            .AutoClear(false);

        await statusLive.StartAsync(async ctx =>
        {
            if (!string.IsNullOrEmpty(lastError))
            {
                
                for (var i = waitingSeconds; i>0; i--)
                {
                    ctx.UpdateTarget(new Markup($"[red]{lastError}[/] [blue](možeš unijeti novu poruku za {i} s)[/]"));
                    await Task.Delay(1000);
                }
                
                lastError = null;

                ctx.UpdateTarget(new Markup("\n[blue]Enter = poruka | ↑↓ scroll | Q/Esc = izlaz[/])"));
            }

            ;
        });
        
        return lastError;
    }




}