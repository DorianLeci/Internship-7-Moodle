using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Internship_7_Moodle.Presentation.Views.Admin;
using Internship_7_Moodle.Presentation.Views.Common;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class AdminMainMenuManager:BaseMainMenuManager
{
    public AdminMainMenuManager(int userId,ChatFeature chatFeature,UserActions userActions) : base(userId,chatFeature,userActions)
    {
    }
    
    public override async Task RunAsync()
    {
        var mainMenu = MenuBuilder.MenuBuilder.CreateAdminMenu(this);

        await MenuRunner.RunMenuAsync(mainMenu,"[yellow] Glavni izbornik[/]",exitChoice:"Odjava");
    }

    public async Task ShowUserDeletionMenuAsync(string title,AdminMenuAction action)
    {
        var usrDeletionMenu = MenuBuilder.MenuBuilder.CreateAdminActionMenu(this,title,action);

        await MenuRunner.RunMenuAsync(usrDeletionMenu, title);       
    }
    
    public async Task ShowUserRoleChangeMenuAsync(string title,AdminMenuAction action)
    {
        var usrRoleChangeMenu = MenuBuilder.MenuBuilder.CreateAdminActionMenu(this,title,action);

        await MenuRunner.RunMenuAsync(usrRoleChangeMenu, title);       
    }
    
    public async Task ShowUsersAsync(string title,AdminMenuAction action,RoleEnum? roleFilter = null)
    {
        var exitRequested = false;

        while (!exitRequested)
        {
            var allUsers = await UserActions.GetAllUsersAsync(Id,roleFilter);
            var allUsersList = allUsers.ToList();
        
            if (allUsersList.Count == 0)
            {
                ConsoleHelper.SleepAndClear(2000,"[red bold]Ne postoje dostupni korisnici.Izlazak...[/]");
                return;
            }

            var usersMenu = action switch
            {
                AdminMenuAction.Delete => MenuBuilder.MenuBuilder.CreateUsersMenu(this,allUsersList,AdminMenuAction.Delete),
                AdminMenuAction.ChangeRole => MenuBuilder.MenuBuilder.CreateUsersMenu(this,allUsersList,AdminMenuAction.ChangeRole),
                AdminMenuAction.ChangeEmail => MenuBuilder.MenuBuilder.CreateUsersMenu(this,allUsersList,AdminMenuAction.Delete),
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
            ConsoleHelper.SleepAndClear(2000,"[blue bold]Odustao si od brisanja korisnika.Izlazak...[/]");
            return;            
        }

        var response=await UserActions.DeleteUserAsync(userToDeleteId);

        AnsiConsole.Clear();
        Writer.Admin.UserDeletionWriter(response);
        
        ConsoleHelper.SleepAndClear(2000);
    }
    
    public async Task HandleUserRoleChangeAsync(int userToDeleteId)
    {
        var choice = await ChoiceMenu.ShowChoiceMenuAsync(("Da", true), ("Ne", false),
            "[yellow]Želiš li promjeniti ulogu korisnika[/]");

        if (!choice)
        {
            AnsiConsole.Clear();
            ConsoleHelper.SleepAndClear(2000,"[blue bold]Odustao si od promjene uloge korisnika.Izlazak...[/]");
            return;            
        }

        var response = await UserActions.ChangeUserRoleAsync(userToDeleteId);

        AnsiConsole.Clear();
        Writer.Admin.UserRoleChangeWriter(response);
        
        ConsoleHelper.SleepAndClear(2000);
    }
    

    
}