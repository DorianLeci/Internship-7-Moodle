using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.Format;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static partial class Writer
{
    public static class Course
    {
        public static void NotificationWriter(List<NotificationResponse> notificationResponses)
        {
            foreach (var notificationResponse in notificationResponses)
            {
                var table = new Table()
                {
                    Border =TableBorder.Ascii
                };
                table.HideHeaders();
                table.AddColumn(new TableColumn("").LeftAligned());

                var headerRow = "";

                if (!string.IsNullOrEmpty(notificationResponse.ProfessorName))
                    headerRow += $"[rgb(0,200,0)]Profesor: {notificationResponse.ProfessorName}[/] |";

                headerRow += $"[yellow]Datum objave: {notificationResponse.CreatedAt.ToDisplayString()}[/] |"
                             + $"[blue]Predmet: {notificationResponse.Subject}[/]";

                table.AddRow(headerRow);

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
            foreach (var materialResponse in materialResponses)
            {
                var table = new Table()
                {
                    Border =TableBorder.Ascii
                };
                table.HideHeaders();
                table.AddColumn(new TableColumn("").LeftAligned());
                table.AddRow($"[rgb(0,200,0)]Materijal: {materialResponse.Title+", "+materialResponse.AuthorName}[/] |"
                             + $"[yellow]Datum objave: {materialResponse.CreatedAt.ToDisplayString()}[/] |" );

                table.AddRow($"[blue]Link: {materialResponse.Url}[/] |");
            
                var panel = new Panel(table)
                {
                    Border =  BoxBorder.None
                };
            
                AnsiConsole.Write(panel);
            }        
        }

        public static void StudentsEnrolledWriter(List<UserResponse> userResponses)
        {
            var table = new Table()
            {
                Border =TableBorder.Ascii
            };                
            table.AddColumn(new TableColumn("[yellow]ID[/]").LeftAligned());
            table.AddColumn(new TableColumn("[rgb(0,200,0)]Ime[/]").LeftAligned());
            table.AddColumn(new TableColumn("[rgb(0,200,0)]Prezime[/]").LeftAligned());
            
            foreach (var user in userResponses)
            {
                table.AddRow(
                    user.Id.ToString(),
                    user.FirstName,
                    user.LastName
                );
                
            }
            AnsiConsole.Write(table);        
        }
        
        public static void NotificationPublishedWriter()
        {
            
            AnsiConsole.MarkupLine("[rgb(0,200,0) bold]Obavijest uspješno kreirana![/]");
        }
        
        public static void MaterialPublishedWriter()
        {
            AnsiConsole.MarkupLine("[rgb(0,200,0) bold]Materijal uspješno dodan![/]");
        }

        public static void StudentAddedWriter(AppResult<UserResponse> result)
        {
            
            if (result.IsFailure)
                Common.ErrorWriter(result,"[red]Dodavanje studenta na kolegij nije uspjelo[/]");

            else
            {
                var idText = $"[yellow] -Id korisnika: {result.Value!.Id}[/]";
                var roleText = $"[yellow] -Ime i prezime: {result.Value.FullName}[/]";
                
                AnsiConsole.Write(new Panel(string.Join("\n",idText,roleText))
                {
                    Header = new PanelHeader("[rgb(0,200,0)]Korisnik uspješno dodan[/]",Justify.Center),
                    Border=BoxBorder.Rounded,
                    Width=40
                });   
            }
                
        }

    }


    
}