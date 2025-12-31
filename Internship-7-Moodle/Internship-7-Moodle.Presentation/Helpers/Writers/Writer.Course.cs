using Internship_7_Moodle.Application.Response.Course;
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
    
    
}