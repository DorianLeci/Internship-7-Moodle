using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response;
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
        var roleText=$"[yellow] -Uloga korisnika: {appResult.Value!.RoleName}[/]";
        
        AnsiConsole.Write(new Panel(string.Join("\n",idText,roleText))
        {
            Header = new PanelHeader("[green]Korisnik uspješno prijavljen[/]",Justify.Center),
            Border=BoxBorder.Rounded,
            Width=40
        });   
        
        return true;        
    }
}