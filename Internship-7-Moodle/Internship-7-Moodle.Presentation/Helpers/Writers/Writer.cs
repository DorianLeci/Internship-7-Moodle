using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response;
using Internship_7_Moodle.Application.Users.Response.Course;
using Internship_7_Moodle.Application.Users.Response.User;
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

    public static void ChatHeaderWriter(ChatResponse chatResponse)
    {
        var otherUserName = chatResponse.OtherUserName;
        AnsiConsole.Write(new Panel($"Chat sa: [yellow]{otherUserName}[/]")
        {
            Header = new PanelHeader("[green]Privatni chat[/]", Justify.Center),
            Border = BoxBorder.Rounded
        });
    }
    public static void ChatWriter(ChatResponse chatResponse,int currentUserId,int scrollOffset,int panelHeight)
    {            
        ConsoleHelper.ClearAndSleep(50);
        const string hasReadMarkup = "[blue]✓✓[/]";
        const string hasNotReadMarkup="[grey]✓✓[/]";
        
        var grid = new Grid();
        grid.AddColumn();
        grid.AddColumn();

        var totalMsg = chatResponse.Messages.Count;

        foreach (var msg in chatResponse.Messages.Skip(Math.Max(0,scrollOffset)).Take(panelHeight))
        {
            var isCurrentUser=msg.SenderId == currentUserId;
            var senderName=msg.SenderId==currentUserId ? "[blue]Ti[/]" : $"[yellow]{msg.SenderName}[/]";
            
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
            
            if(isCurrentUser)
                grid.AddRow(panel, new Markup("")); 
            
            else
                grid.AddRow(new Markup(""),panel);
            
        }
        AnsiConsole.Write(grid);
        
    }
    
}