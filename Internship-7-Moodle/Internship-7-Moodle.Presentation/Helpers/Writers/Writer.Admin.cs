using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static partial class Writer
{
    public static class Admin
    {
        public static void UserDeletionWriter(AppResult<SuccessResponse> result)
        {
            
            if (result.IsFailure)
                Common.ErrorWriter(result,"[red]Brisanje korisnika nije uspjelo[/]");

            else
            {
                AnsiConsole.Write(new Panel($"[rgb(0,200,0)]{result.Value!.Message}[/]")
                {
                    Border=BoxBorder.Rounded,
                    Width=40
                });   
            }
                
        }
        
        public static void UserRoleChangeWriter(AppResult<ChangeRoleResponse> result)
        {
            
            if (result.IsFailure)
                Common.ErrorWriter(result,"[red]Promjena uloge neuspješna[/]");

            else
            {
                var idText = $"[yellow] -Id korisnika: {result.Value!.Id}[/]";
                var oldRoleText = $"[yellow] -Stara uloga: {result.Value.NewRoleNameCroatian}[/]";
                var newRoleText = $"[yellow] -Nova uloga: {result.Value.OldRoleNameCroatian}[/]";
                
                AnsiConsole.Write(new Panel(string.Join("\n",idText,oldRoleText,newRoleText))
                {
                    Header = new PanelHeader("[rgb(0,200,0)]Uloga uspješno izmijenjena[/]",Justify.Center),
                    Border=BoxBorder.Rounded,
                    Width=40
                });   
            }
                
        }
    }
}