using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views;

public class MainMenuManager
{
    private readonly UserActions _userActions;
    private readonly RoleEnum _roleName;
    private readonly int _userId;
    
    public RoleEnum RoleName => _roleName;
    public int UserId => _userId;

    public MainMenuManager(UserActions userActions,RoleEnum roleName,int userId)
    {
        _userActions = userActions;
        _roleName = roleName;
        _userId = userId;
    }

    public async Task RunAsync()
    {
        bool logoutRequested = false;

        var mainMenu = MenuBuilder.CreateMainMenu(this);

        while (!logoutRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Glavni izbornik[/]")
                    .AddChoices(mainMenu.Keys));

            logoutRequested = await mainMenu[choice]();            
        }
    }

    public async Task ShowCourseMenuAsync(int studentId)
    {
        ConsoleHelper.ClearAndSleep();
        
        var studentCourses = await _userActions.GetStudentCoursesAsync(studentId);
        
        var studentCoursesList = studentCourses.ToList();
        if (studentCoursesList.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]Ne postoje dostupni kolegiji.Izlazak...[/]");
            ConsoleHelper.ClearAndSleep(2000);
            return;
        }

        var exitRequested = false;
        var courseMenu = MenuBuilder.CreateCourseMenu(this,studentCoursesList);

        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Moji kolegiji[/]")
                    .AddChoices(courseMenu.Keys));

            exitRequested = await courseMenu[choice]();     
        }


    }

    public async Task ShowCourseSubmenuAsync(StudentCourseResponse course)
    {
        
    }
    
}