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
            var prompt = new SelectionPrompt<string>()
                .Title("[yellow] Korisnici s kojima još nisi komunicirao[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Stisni strelicu prema dolje da vidiš više)[/]")
                .EnableSearch()
                .SearchPlaceholderText("Upiši tekst da pretražuješ")
                .AddChoices(usrChatMenu.Keys);
            
            prompt.SearchHighlightStyle=new Style().Background(ConsoleColor.DarkBlue);

            var choice = AnsiConsole.Prompt(prompt);
                
            
                
            exitRequested = await usrChatMenu[choice]();     
        }        
        

    }

    public async Task OpenPrivateChatAsync(int otherUserId)
    {
        const int panelHeight = 3;
        
        var result=await UserActions.GetOrCreateChatAsync(UserId, otherUserId);

        if (result.IsFailure)
        {
            Writer.ChatErrorWriter(result);
            ConsoleHelper.ClearAndSleep(2000,"[blue]Izlazak...[/]");
            return;
        }

        var chatResponse = result.Value;

        if (chatResponse == null)
        {
            Writer.ChatErrorWriter(result);
            ConsoleHelper.ClearAndSleep(2000,"[blue]Izlazak...[/]");
            return;
        }
        
        Writer.ChatHeaderWriter(chatResponse);
        Writer.ChatWriter(chatResponse,chatResponse.CurrentUserId,0,panelHeight);
        
        bool exitChat = false;
        int scrollOffset = 0;
        
        while (!exitChat)
        {
            var keyInfo=Console.ReadKey(intercept:true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    scrollOffset--;
                    
                    if (scrollOffset < 0)
                        scrollOffset = 0;
                    
                    Writer.ChatWriter(chatResponse,chatResponse.CurrentUserId,scrollOffset,panelHeight);
                    break;
                
                case ConsoleKey.DownArrow:
                    scrollOffset++;
                    
                    if(scrollOffset>=(chatResponse.Messages.Count-panelHeight))
                        scrollOffset = chatResponse.Messages.Count-panelHeight;
                    
                    Writer.ChatWriter(chatResponse,chatResponse.CurrentUserId,scrollOffset,panelHeight);
                    break;
                
                case ConsoleKey.Enter:
                    var textResult = FieldPrompt.MessageContentValidation("Unesi poruku(max 500 znakova)",
                        text => PromptFunctions.ContentCheck(text));
                    
                    if (!textResult.Successful) break;
                    
                    var messageResult = await UserActions.SendPrivateMessageAsync(
                        UserId,
                        otherUserId,
                        textResult.Value
                    );

                    if (messageResult.Value != null)
                    {
                        chatResponse.Messages.Add(messageResult.Value);
                    }
                    
                    Writer.ChatWriter(chatResponse,chatResponse.CurrentUserId,scrollOffset,panelHeight);
                    break;
                    
            }
            
        }

 

    }

}