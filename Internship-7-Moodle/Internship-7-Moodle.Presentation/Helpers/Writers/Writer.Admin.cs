using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
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

        public static void RegisteredUserCountWriter(List<CountByRoleResponse> responses)
        {
            
            var table = new Table()
                .Border(TableBorder.Rounded)
                .AddColumn(new TableColumn("Uloga").Centered().Width(15)) 
                .AddColumn(new TableColumn("Broj").Centered().Width(10));
            
            foreach (var response in responses)
            {
                table.AddRow(response.RoleNameCroatian, response.Count.ToString());
            }
            
            AnsiConsole.MarkupLine("[yellow] Broj registiranih korisnika po ulozi\n[/]");
            AnsiConsole.Write(table);
        }
    }
}