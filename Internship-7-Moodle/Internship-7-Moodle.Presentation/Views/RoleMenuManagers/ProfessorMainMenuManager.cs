using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Views.Common;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class ProfessorMainMenuManager:BaseMainMenuManager
{
    private readonly CourseActions _courseActions;
    public ProfessorMainMenuManager(int userId,ChatFeature chatFeature,UserActions userActions, CourseActions courseActions) : base(userId,chatFeature,userActions)
    {
        _courseActions = courseActions;
    }

    public override async Task RunAsync()
    { 
        var logoutRequested = false;

        var mainMenu = MenuBuilder.MenuBuilder.CreateStudentMenu(this);

        while (!logoutRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Glavni izbornik[/]")
                    .AddChoices(mainMenu.Keys));

            logoutRequested = await mainMenu[choice]();            
        }
    }

    public async Task ShowCourseManagementMenu(int professorId)
    {
        ConsoleHelper.ClearAndSleep();
    }
}