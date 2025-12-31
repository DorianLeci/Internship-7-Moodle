using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static partial class Writer
{
    public static class Authentication
    {
        public static bool RegisterUserWriter(AppResult<SuccessPostResponse> appResult)
        {
            AnsiConsole.WriteLine();
            
            if (appResult.IsFailure)
            {
                Common.ErrorWriter(appResult,"[red]Registracija nije uspjela[/]");
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
            AnsiConsole.WriteLine();
            
            if (appResult.IsFailure)
            {
                Common.ErrorWriter(appResult,"[red]Prijava nije uspjela[/]","[red]Ako ne želiš odustati od prijave pričekaj 30 sekundi prije ponovnog pokušaja[/]");
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

    }
}