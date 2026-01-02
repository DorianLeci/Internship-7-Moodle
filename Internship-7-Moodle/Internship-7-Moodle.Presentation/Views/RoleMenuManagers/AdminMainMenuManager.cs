using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
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

    public async Task ShowUserDeletionMenuAsync(string title)
    {
        var usrDeletionMenu = MenuBuilder.MenuBuilder.CreateUserDeletionMenu(this,title);

        await MenuRunner.RunMenuAsync(usrDeletionMenu, title);       
    }
    public async Task ShowUsersToDeleteAsync(string title,RoleEnum? roleFilter = null)
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
            
            var usersToDeleteMenu = MenuBuilder.MenuBuilder.CreateUsersToDeleteMenu(this,allUsersList);
            
            var prompt = new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText("[grey](Stisni strelicu prema dolje da vidiš više)[/]")
                .EnableSearch()
                .SearchPlaceholderText("Upiši ime korisnika da pretražuješ")
                .AddChoices(usersToDeleteMenu.Keys);

            prompt.SearchHighlightStyle = new Style().Background(ConsoleColor.DarkBlue);

            var choice = AnsiConsole.Prompt(prompt);

            exitRequested = await usersToDeleteMenu[choice]();

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
}