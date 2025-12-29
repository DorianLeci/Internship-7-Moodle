using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Internship_7_Moodle.Presentation.Views.Common;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class StudentMainMenuManager:BaseMainMenuManager
{
    public StudentMainMenuManager(UserActions userActions,int userId) : base(userActions,userId)
    {
    }

    public override async Task RunAsync()
    {
        bool logoutRequested = false;

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
    
    public async Task ShowCourseMenuAsync(int studentId)
    {
        ConsoleHelper.ClearAndSleep();
        
        var studentCourses = await UserActions.GetStudentCoursesAsync(studentId);
        
        var studentCoursesList = studentCourses.ToList();
        if (studentCoursesList.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]Ne postoje dostupni kolegiji.Izlazak...[/]");
            ConsoleHelper.ClearAndSleep(2000);
            return;
        }

        var exitRequested = false;
        var courseMenu = MenuBuilder.MenuBuilder.CreateCourseMenu(this,studentCoursesList);

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
        ConsoleHelper.ClearAndSleep();

        var exitRequested = false;
        var courseSubmenu = MenuBuilder.MenuBuilder.CreateCourseSubmenu(this, course.CourseId);
        
        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow] Kolegij screen[/]")
                    .AddChoices(courseSubmenu.Keys));

            exitRequested = await courseSubmenu[choice]();     
        }
    }

    public async Task ShowCourseNotificationsAsync(int courseId)
    {
        ConsoleHelper.ClearAndSleep();

        var notifications = await UserActions.GetAllNotificationsAsync(courseId);
        var notificationList = notifications.ToList();
        Writer.Course.NotificationWriter(notificationList);

        ConsoleHelper.ScreenExit(1500);
    }
    
    public async Task ShowCourseMaterialsAsync(int courseId)
    {
        ConsoleHelper.ClearAndSleep();

        var materials = await UserActions.GetAllMaterialsAsync(courseId);
        var materialList = materials.ToList();
        Writer.Course.MaterialsWriter(materialList);

        ConsoleHelper.ScreenExit(1500); 
    }
}