using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response;
using Internship_7_Moodle.Application.Users.Response.Course;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static class Writer
{
    public static bool RegisterUserWriter(AppResult<SuccessPostResponse> appResult)
    {
        if (appResult.IsFailure)
        {
            ErrorWriter(appResult,"[red]Registracija nije uspjela[/]");
            return false;
        }
        
        var text = $"[yellow] -Id korisnika: {appResult.Value!.Id}[/]";
        
        AnsiConsole.Write(new Panel(text)
        {
            Header = new PanelHeader("[green]Korisnik uspješno registriran[/]",Justify.Center),
            Border=BoxBorder.Rounded,
            Width=40
        });   
        
        return true;
        
    }

    public static bool LoginUserWriter(AppResult<UserLoginResponse> appResult)
    {
        if (appResult.IsFailure)
        {
            ErrorWriter(appResult,"[red]Prijava nije uspjela[/]","[red]Ako ne želiš odustati od prijave pričekaj 30 sekundi prije ponovnog pokušaja[/]");
            return false;
        }
        
        var idText = $"[yellow] -Id korisnika: {appResult.Value!.Id}[/]";
        var roleText=$"[yellow] -Uloga korisnika: {appResult.Value.RoleName}[/]";
        
        AnsiConsole.Write(new Panel(string.Join("\n",idText,roleText))
        {
            Header = new PanelHeader("[green]Korisnik uspješno prijavljen[/]",Justify.Center),
            Border=BoxBorder.Rounded,
            Width=40
        });   
        
        return true;        
    }

    private static void ErrorWriter<T>(AppResult<T> appResult,string headerMessage,string? markupMessage=null) where T:class
    {
        var errorMessages=string.Join("\n",appResult.Errors.Select(e => $"[red]-{e.Message}[/]"));
            
        AnsiConsole.Write(new Panel(errorMessages)
        {
            Header = new PanelHeader(headerMessage,Justify.Center),
            Border=BoxBorder.Rounded
        });
        
        if(markupMessage!=null)
            AnsiConsole.MarkupLine(markupMessage);
    }
    
    public static void NotificationWriter(List<NotificationResponse> notificationResponses)
    {
        if (notificationResponses.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]Ne postoje dostupni kolegiji.Izlazak...[/]");
            ConsoleHelper.ClearAndSleep(1000);
            return;
        }

        foreach (var notificationResponse in notificationResponses)
        {
            var table = new Table()
            {
                Border =TableBorder.Ascii
            };
            table.HideHeaders();
            table.AddColumn(new TableColumn("").LeftAligned());
            table.AddRow($"[green]Profesor: {notificationResponse.ProfessorName}[/] |"
                         +$"[yellow]Datum objave: {notificationResponse.CreatedAt}[/] |"
                         + $"[blue]Predmet: {notificationResponse.Subject}[/]");

            table.AddRow($"\n[b]{notificationResponse.Content}[/]");
            

            var panel = new Panel(table)
            {
              Border =  BoxBorder.None
            };
            
            AnsiConsole.Write(panel);
        }
    }


    public static void MaterialsWriter(List<MaterialResponse> materialResponses)
    {
        if (materialResponses.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]Ne postoje dostupni materijali.Izlazak...[/]");
            ConsoleHelper.ClearAndSleep(2000);
            return;
        }

        foreach (var materialResponse in materialResponses)
        {
            var table = new Table()
            {
                Border =TableBorder.Ascii
            };
            table.HideHeaders();
            table.AddColumn(new TableColumn("").LeftAligned());
            table.AddRow($"[green]Materijal: {materialResponse.Title+", "+materialResponse.AuthorName}[/] |"
                         + $"[yellow]Datum objave: {materialResponse.CreatedAt}[/] |" );

            table.AddRow($"[blue]Link: {materialResponse.Url}[/] |");
            
            var panel = new Panel(table)
            {
                Border =  BoxBorder.None
            };
            
            AnsiConsole.Write(panel);
        }        
    }


    public static void ChatErrorWriter(AppResult<ChatResponse> result)
    {
        ErrorWriter(result,"[red]Nije moguće otvoriti chat[/]");
    }

    private static void ChatHeaderWriter(ChatResponse chatResponse)
    {
        var otherUserName = chatResponse.OtherUserName;
        AnsiConsole.Write(new Panel($"Chat sa: [yellow]{otherUserName}[/]")
        {
            Header = new PanelHeader("[green]Privatni chat[/]", Justify.Center),
            Border = BoxBorder.Rounded
        });
    }
    public static async Task ChatWriter(ChatResponse chatResponse,UserActions userActions,int scrollOffset,int panelHeight)
    {            
        ConsoleHelper.ClearAndSleep(10);
        ChatHeaderWriter(chatResponse);

        const string hasReadMarkup = "[blue]✓✓[/]";
        const string hasNotReadMarkup="[grey]✓✓[/]";

        var grid = new Grid();
        grid.AddColumn(new GridColumn { Width = 50 });
        grid.AddColumn(new GridColumn { Width = 50 });
        
        var visibleMsg= await UpdateMessageList(chatResponse, userActions, scrollOffset,panelHeight);
        
        foreach (var msg in visibleMsg)
        {
            var isCurrentUser = msg.SenderId == chatResponse.CurrentUserId;
            var senderName=msg.SenderId==chatResponse.CurrentUserId ? "[blue]Ti[/]" : $"[yellow]{msg.SenderName}[/]";
            
            var infoTable = new Table()
            {
                Border = TableBorder.None,
                ShowHeaders = false,
            };

            infoTable.AddColumn("");
            infoTable.AddRow($"[grey]{msg.SentAt}[/] {(isCurrentUser ? (msg.IsRead? hasReadMarkup : hasNotReadMarkup): "") }");
            
            var panel = new Panel(new Rows(new Markup(msg.Content),infoTable))
            {
                Header = new PanelHeader(senderName, Justify.Left),
                Border = BoxBorder.Heavy,
                BorderStyle=isCurrentUser ? new Style(Color.BlueViolet) : new Style(Color.Grey),
                
            };
            
            var emptyPanel = new Panel(" ") 
            {
                Border = BoxBorder.None,
                Padding = new Padding(0),
                Expand = true
            };
            if(isCurrentUser)
                grid.AddRow(panel,emptyPanel);

            else
                grid.AddRow(emptyPanel,panel);   
            
        }
        AnsiConsole.Write(grid);
        
    }

    private static async Task<List<PrivateMessageResponse>> UpdateMessageList(ChatResponse chatResponse,UserActions userActions,int scrollOffset,int panelHeight)
    {
        var visibleMsg = chatResponse.Messages
            .Skip(Math.Max(0, scrollOffset))
            .Take(panelHeight)
            .ToList();
        
        var visibleUnreadMsg = visibleMsg
            .Where(m => m.ReceiverId == chatResponse.CurrentUserId && !m.IsRead)
            .Select(m => m.MessageId)
            .ToList();
        
        if(visibleUnreadMsg.Count>0)
            await userActions.UpdateUnreadMessagesAsync(visibleUnreadMsg);
        
        return visibleMsg;
    }
    
}