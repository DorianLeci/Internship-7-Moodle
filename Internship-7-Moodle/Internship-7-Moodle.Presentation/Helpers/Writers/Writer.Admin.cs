using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Chat;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static partial class Writer
{
    public static class Admin
    {
        public static void UserDeletionWriter(AppResult<SuccessResponse> result)
        {

            if (result.IsFailure)
                Common.ErrorWriter(result, "[red]Brisanje korisnika nije uspjelo[/]");

            else
            {
                AnsiConsole.Write(new Panel($"[rgb(0,200,0)]{result.Value!.Message}[/]")
                {
                    Border = BoxBorder.Rounded,
                    Width = 40
                });
            }

        }

        public static void UserRoleChangeWriter(AppResult<ChangeRoleResponse> result)
        {
            ConsoleHelper.SleepAndClear(1000);
            
            if (result.IsFailure)
                Common.ErrorWriter(result, "[red]Promjena uloge neuspješna[/]");

            else
            {
                var idText = $"[yellow] -Id korisnika: {result.Value!.Id}[/]";
                var oldRoleText = $"[yellow] -Stara uloga: {result.Value.OldRoleNameCroatian}[/]";
                var newRoleText = $"[yellow] -Nova uloga: {result.Value.NewRoleNameCroatian}[/]";

                AnsiConsole.Write(new Panel(string.Join("\n", idText, oldRoleText, newRoleText))
                {
                    Header = new PanelHeader("[rgb(0,200,0)]Uloga uspješno izmijenjena[/]", Justify.Center),
                    Border = BoxBorder.Rounded,
                    Width = 40
                });
            }
        }

        public static void UserEmailChangeWriter(AppResult<ChangeEmailResponse> result)
        {
            ConsoleHelper.SleepAndClear(1000);
            
            if (result.IsFailure)
                Common.ErrorWriter(result, "[red]Promjena emaila neuspješna[/]");

            else
            {
                var idText = $"[yellow] -Id korisnika: {result.Value!.Id}[/]";
                var oldEmailText = $"[yellow] -Stari email: {result.Value.OldEmail}[/]";
                var newEmailText = $"[yellow] -Novi email: {result.Value.NewEmail}[/]";

                AnsiConsole.Write(new Panel(string.Join("\n", idText, oldEmailText, newEmailText))
                {
                    Header = new PanelHeader("[rgb(0,200,0)]Email uspješno izmijenjen[/]", Justify.Center),
                    Border = BoxBorder.Rounded,
                    Width = 40
                });
            }
        }

        public static void RegisteredUserCountWriter(List<CountByRoleResponse> responses,PeriodEnum period)
        {
            var markupTitle = period switch
            {
                PeriodEnum.Today => "Broj registiranih korisnika po ulozi(na dašanji dan)",
                PeriodEnum.ThisMonth => "Broj registiranih korisnika po ulozi(ovaj mjesec)",
                PeriodEnum.Total => "Broj registiranih korisnika po ulozi(ukupno)",
                _ => "-"
            };
            
            var table = new Table()
                .Border(TableBorder.Rounded)
                .AddColumn(new TableColumn(new Markup("[yellow]Uloga[/]"))) 
                .AddColumn(new TableColumn(new Markup("[rgb(0,200,0)]Broj[/]")));
            
            foreach (var response in responses)
            {
                table.AddRow(response.RoleNameCroatian, response.Count.ToString());
            }
            
            AnsiConsole.MarkupLine($"[yellow] {markupTitle}\n[/]");
            AnsiConsole.Write(table);
        }

        public static void CourseCountWriter(int courseCount,PeriodEnum period)
        {

            var markupTitle = period switch
            {
                PeriodEnum.Today => "Broj kolegija(dodanih na dašanji dan)",
                PeriodEnum.ThisMonth => "Broj kolegija(dodanih ovaj mjesec)",
                PeriodEnum.Total => "Broj kolegija(ukupno)",
                _ => "-"
            };
            
            var table = new Table()
                .Border(TableBorder.Rounded)
                .AddColumn(new TableColumn(new Markup("[rgb(0,200,0)]Broj[/]")));
            
            table.AddRow(courseCount.ToString());
            
            AnsiConsole.MarkupLine($"[yellow] {markupTitle}\n[/]");
            AnsiConsole.Write(table);
        }

        public static void TopCoursesWriter(List<TopCourseResponse> responses, PeriodEnum period)
        {
            var markupTitle = period switch
            {
                PeriodEnum.Today => "Top 3 kolegija po broju upisanih studenata(na dašanji dan)",
                PeriodEnum.ThisMonth => "Top 3 kolegija po broju upisanih studenata(ovaj mjesec)",
                PeriodEnum.Total => "Top 3 kolegija po broju upisanih studenata(ukupno)",
                _ => "-"
            };

            var table = new Table()
                .Border(TableBorder.Rounded)
                .AddColumn(new TableColumn(new Markup("[yellow]Id[/]")))
                .AddColumn(new TableColumn(new Markup("[rgb(0,200,0)]Ime kolegija[/]")))
                .AddColumn(new TableColumn(new Markup("[rgb(0,200,0)]Broj upisanih studenata[/]")));

            foreach (var response in responses)
                table.AddRow(response.CourseId.ToString(),response.CourseName,response.EnrollmentCount.ToString());
            
            AnsiConsole.MarkupLine($"[yellow] {markupTitle}\n[/]");
            AnsiConsole.Write(table);


        }
        
        public static void TopUsersWriter(List<TopUsersByMsgResponse> responses, PeriodEnum period)
        {
            var markupTitle = period switch
            {
                PeriodEnum.Today => "Top 3 korisnika po broju poslanih poruka(na dašanji dan)",
                PeriodEnum.ThisMonth => "Top 3 korisnika po broju poslanih poruka(ovaj mjesec)",
                PeriodEnum.Total => "Top 3 korisnika po broju poslanih poruka(ukupno)",
                _ => "-"
            };

            var table = new Table()
                .Border(TableBorder.Rounded)
                .AddColumn(new TableColumn(new Markup("[yellow]Id[/]")))
                .AddColumn(new TableColumn(new Markup("[rgb(0,200,0)]Ime korisnika[/]")))
                .AddColumn(new TableColumn(new Markup("[rgb(0,200,0)]Broj poslanih poruka[/]")));

            foreach (var response in responses)
                table.AddRow(response.UserId.ToString(),response.FullName,response.MsgSentCount.ToString());
            
            AnsiConsole.MarkupLine($"[yellow] {markupTitle}\n[/]");
            AnsiConsole.Write(table);


        }
    }
}