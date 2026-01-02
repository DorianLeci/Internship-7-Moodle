using Internship_7_Moodle.Application.Common.Model;
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
    }
}