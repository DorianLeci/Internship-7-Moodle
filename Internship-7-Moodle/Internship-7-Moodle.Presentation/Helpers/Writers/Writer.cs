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
            var errorMessages=string.Join("\n",appResult.Errors.Select(e => $"[red]-{e.Message}[/]"));
            
            AnsiConsole.Write(new Panel(errorMessages)
            {
                Header = new PanelHeader("[red]Registracija nije uspjela[/]",Justify.Center),
                Border=BoxBorder.Rounded
            });

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
            var errorMessages=string.Join("\n",appResult.Errors.Select(e => $"[red]-{e.Message}[/]"));
            
            AnsiConsole.Write(new Panel(errorMessages)
            {
                Header = new PanelHeader("[red]Prijava nije uspjela[/]",Justify.Center),
                Border=BoxBorder.Rounded
            });
            AnsiConsole.MarkupLine("[red]Ako ne želiš odustati od prijave pričekaj 30 sekundi prije ponovnog pokušaja[/]");
            
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

    public static void NotificationWriter(List<NotificationResponse> notificationResponses)
    {
        if (notificationResponses.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]Ne postoje dostupni kolegiji.[/]");
            ConsoleHelper.ClearAndSleep(2000);
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
            AnsiConsole.MarkupLine("[red]Ne postoje dostupni materijali.[/]");
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
    
}