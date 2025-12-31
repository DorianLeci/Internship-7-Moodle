using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Internship_7_Moodle.Presentation.Views.Common;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class StudentMainMenuManager:BaseMainMenuManager
{
    private readonly CourseActions _courseActions;
    
    public StudentMainMenuManager(int userId, ChatFeature chatFeature, UserActions userActions, CourseActions courseActions) : base(userId,chatFeature,userActions)
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
    
    public async Task ShowCourseMenuAsync(int studentId)
    {
        ConsoleHelper.SleepAndClear();
        
        var studentCourses = await UserActions.GetStudentCoursesAsync(studentId);
        
        var studentCoursesList = studentCourses.ToList();
        if (studentCoursesList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red]Ne postoje dostupni kolegiji.Izlazak...[/]");
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
    
    public async Task ShowCourseSubmenuAsync(CourseResponse course)
    {
        ConsoleHelper.SleepAndClear();

        var exitRequested = false;
        var courseSubmenu = MenuBuilder.MenuBuilder.CreateCourseSubmenu(this, course.CourseId);
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[yellow] Kolegij screen[/]")
                .AddChoices(courseSubmenu.Keys));
        
        while (!exitRequested)
        {
            exitRequested = await courseSubmenu[choice]();     
        }
    }

    public async Task ShowCourseNotificationsAsync(int courseId)
    {
        ConsoleHelper.SleepAndClear();

        var notifications = await _courseActions.GetAllNotificationsAsync(courseId);
        var notificationList = notifications.ToList();
        
        if (notificationList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(1000,"[red]Ne postoje dostupni kolegiji.Izlazak...[/]");
            return;
        }
        
        Writer.Course.NotificationWriter(notificationList);

        ConsoleHelper.ScreenExit(1500);
    }
    
    public async Task ShowCourseMaterialsAsync(int courseId)
    {
        ConsoleHelper.SleepAndClear();

        var materials = await _courseActions.GetAllMaterialsAsync(courseId);
        var materialList = materials.ToList();
        
        if (materialList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red]Ne postoje dostupni materijali.Izlazak...[/]");
            return;
        }
        
        Writer.Course.MaterialsWriter(materialList);

        ConsoleHelper.ScreenExit(1500); 
    }
}