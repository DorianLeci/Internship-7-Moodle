using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
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
                    headerRow += $"[green]Profesor: {notificationResponse.ProfessorName}[/] |";

                headerRow += $"[yellow]Datum objave: {notificationResponse.CreatedAt}[/] |"
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

        public static void StudentsEnrolledWriter(List<UserResponse> userResponses)
        {
            var table = new Table()
            {
                Border =TableBorder.Ascii
            };                
            table.AddColumn(new TableColumn("[yellow]ID[/]").LeftAligned());
            table.AddColumn(new TableColumn("[green]Ime[/]").LeftAligned());
            table.AddColumn(new TableColumn("[green]Prezime[/]").LeftAligned());
            
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
            AnsiConsole.MarkupLine("[green]Obavijest uspješno kreirana![/]");
        }
        
        public static void MaterialPublishedWriter()
        {
            AnsiConsole.MarkupLine("[green]Materijal uspješno dodan![/]");
        }

    }


    
}