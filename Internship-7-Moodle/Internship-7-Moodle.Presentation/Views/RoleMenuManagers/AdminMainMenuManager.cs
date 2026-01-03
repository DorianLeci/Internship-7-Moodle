using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.PromptFunctions;
using Internship_7_Moodle.Presentation.Helpers.PromptHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Internship_7_Moodle.Presentation.Views.Admin;
using Internship_7_Moodle.Presentation.Views.Common;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class AdminMainMenuManager : BaseMainMenuManager
{
    private readonly CourseActions _courseActions;
    private readonly ChatActions _chatActions;
    
    public AdminMainMenuManager(int userId, ChatFeature chatFeature, UserActions userActions, CourseActions courseActions, ChatActions chatActions) : base(userId,
        chatFeature, userActions)
    {
        _courseActions = courseActions;
        _chatActions = chatActions;
    }

    public override async Task RunAsync()
    {
        var mainMenu = MenuBuilder.MenuBuilder.CreateAdminMenu(this);

        await MenuRunner.RunMenuAsync(mainMenu, "[yellow] Glavni izbornik[/]", exitChoice: "Odjava");
    }

    public async Task ShowUserDeletionMenuAsync(string title, AdminMenuAction action)
    {
        var usrDeletionMenu = MenuBuilder.MenuBuilder.CreateAdminActionMenu(this, title, action);

        await MenuRunner.RunMenuAsync(usrDeletionMenu, title);
    }

    public async Task ShowUserRoleChangeMenuAsync(string title, AdminMenuAction action)
    {
        var usrRoleChangeMenu = MenuBuilder.MenuBuilder.CreateAdminActionMenu(this, title, action);

        await MenuRunner.RunMenuAsync(usrRoleChangeMenu, title);
    }

    public async Task ShowUsersAsync(string title, AdminMenuAction action, RoleEnum? roleFilter = null)
    {
        var exitRequested = false;

        while (!exitRequested)
        {
            var allUsers = await UserActions.GetAllUsersByRoleAsync(roleFilter);
            var allUsersList = allUsers.ToList();

            if (allUsersList.Count == 0)
            {
                ConsoleHelper.SleepAndClear(2000, "[red bold]Ne postoje dostupni korisnici.Izlazak...[/]");
                return;
            }

            var usersMenu = action switch
            {
                AdminMenuAction.Delete => MenuBuilder.MenuBuilder.CreateUsersMenu(this, allUsersList,
                    AdminMenuAction.Delete),
                AdminMenuAction.ChangeRole => MenuBuilder.MenuBuilder.CreateUsersMenu(this, allUsersList,
                    AdminMenuAction.ChangeRole),
                AdminMenuAction.ChangeEmail => MenuBuilder.MenuBuilder.CreateUsersMenu(this, allUsersList,
                    AdminMenuAction.ChangeEmail),
                _ => throw new ArgumentOutOfRangeException(nameof(action), "Nepoznata akcija")
            };


            var prompt = new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText("[grey](Stisni strelicu prema dolje da vidiš više)[/]")
                .EnableSearch()
                .SearchPlaceholderText("Upiši ime korisnika da pretražuješ")
                .AddChoices(usersMenu.Keys);

            prompt.SearchHighlightStyle = new Style().Background(ConsoleColor.DarkBlue);

            var choice = AnsiConsole.Prompt(prompt);
            
            if(choice!=MenuRunner.exitChoiceConst)
                ConsoleHelper.MenuChoiceSuccess(MenuRunner.successMsg);
            
            exitRequested = await usersMenu[choice]();

        }
    }

    public async Task HandleUserDeleteAsync(int userToDeleteId)
    {
        var choice = await ChoiceMenu.ShowChoiceMenuAsync(("Da", true), ("Ne", false),
            "[yellow]Želiš li izbrisati korisnika[/]");

        if (!choice)
        {
            AnsiConsole.Clear();
            ConsoleHelper.SleepAndClear(2000, "[blue bold]Odustao si od brisanja korisnika.Izlazak...[/]");
            return;
        }

        var response = await UserActions.DeleteUserAsync(userToDeleteId);

        AnsiConsole.Clear();
        Writer.Admin.UserDeletionWriter(response);

        ConsoleHelper.SleepAndClear(2000);
    }

    public async Task HandleUserRoleChangeAsync(int userToChangeId)
    {
        var choice = await ChoiceMenu.ShowChoiceMenuAsync(("Da", true), ("Ne", false),
            "[yellow]Želiš li promjeniti ulogu korisnika[/]");

        if (!choice)
        {
            AnsiConsole.Clear();
            ConsoleHelper.SleepAndClear(2000, "[blue bold]Odustao si od promjene uloge korisnika.Izlazak...[/]");
            return;
        }

        var response = await UserActions.ChangeUserRoleAsync(userToChangeId);

        AnsiConsole.Clear();
        Writer.Admin.UserRoleChangeWriter(response);

        ConsoleHelper.SleepAndClear(4000);
    }


    public async Task HandleUserEmailChangeAsync(int userToChangeId)
    {
        const string funcExit = "[blue bold]Izlazak iz promjene emaila..[/]";
        while (true)
        {
            var emailResult = await FieldPrompt.PromptWithValidation(() => ChoiceMenu.ShowChoiceMenuAsync(),
                "Unesi email",
                PromptFunctions.UserRegister.EmailCheck);

            if (emailResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000, funcExit);
                return;
            }

            var response = await UserActions.ChangeUserEmailAsync(userToChangeId, emailResult.Value);
            
            Writer.Admin.UserEmailChangeWriter(response);

            if (response.IsFailure)
            {
                var isNewAttemptRequested = await ChoiceMenu.ShowChoiceMenuAsync(("Pokušaj ponovno", true),
                    ("Odustani", false), "[yellow]Želiš li pokušati ponovno?[/]");
                if (isNewAttemptRequested) continue;

                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000, funcExit);
                return;

            }

            ConsoleHelper.SleepAndClear(6000);
            return;
        }

    }

    public async Task ShowStatisticsMenuAsync(string title)
    {
        var statMenu = MenuBuilder.MenuBuilder.CreateStatisticsMenu(this);
        
        await MenuRunner.RunMenuAsync(statMenu,title);
    }

    public async Task ShowMetricsMenuAsync(StatisticsMenuAction action,string title)
    {
        var metricsMenu=MenuBuilder.MenuBuilder.CreateMetricsMenu(this,action);
        
        await MenuRunner.RunMenuAsync(metricsMenu,title);
    }
    
    public async Task ShowRegisteredUserCountByRoleAsync(PeriodEnum period)
    {
        var countByRole = await UserActions.GetAllUsersByRoleCountAsync(period);
        
        var countByRoleList=countByRole.ToList();

        if (countByRoleList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red bold]Ne postoje registrirani korisnici u ovom razdoblju.Izlazak...[/]");
            return;            
        }
        
        Writer.Admin.RegisteredUserCountWriter(countByRoleList,period);
            
        ConsoleHelper.ScreenExit(1500);
    }

    public async Task ShowCourseCountAsync(PeriodEnum period)
    {
        var courseCountResponse = await _courseActions.GetCourseCountAsync(period);
        
        Writer.Admin.CourseCountWriter(courseCountResponse.CourseCount,period);
            
        ConsoleHelper.ScreenExit(1500);
    }

    public async Task ShowTopCoursesByEnrollmentAsync(PeriodEnum period)
    {
        var topCourseResponses = await _courseActions.GetTopCoursesByEnrollmentAsync(period);
        
        var topCoursesList=topCourseResponses.ToList();

        if (topCoursesList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red bold]Ne postoje upisani studenti u ovom razdoblju.Izlazak...[/]");
            return;                 
        }
        
        Writer.Admin.TopCoursesWriter(topCoursesList,period);
            
        ConsoleHelper.ScreenExit(1500);
        
    }

    public async Task ShowTopUsersByMsgSentAsync(PeriodEnum period)
    {
        var topUsersResponses = await _chatActions.GetTopUsersByMsgSentAsync(period);
        
        var topUsersList=topUsersResponses.ToList();

        if (topUsersList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red bold]Niti jedan korisnik nije poslao poruku u ovom razdoblju.Izlazak...[/]");
            return;                 
        }
        
        Writer.Admin.TopUsersWriter(topUsersList,period);
            
        ConsoleHelper.ScreenExit(1500);        
    }
}