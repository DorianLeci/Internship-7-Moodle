using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Enumerations;
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
        var mainMenu = MenuBuilder.MenuBuilder.CreateStudentMenu(this);

        await MenuRunner.RunMenuAsync(mainMenu, "[yellow] Glavni izbornik[/]",exitChoice:"Odjava");
    }
    
    public async Task ShowCourseMenuAsync(int studentId)
    {
        
        var studentCourses = await UserActions.GetStudentCoursesAsync(studentId);
        
        var studentCoursesList = studentCourses.ToList();
        if (studentCoursesList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red bold]Ne postoje dostupni kolegiji.Izlazak...[/]");
            return;
        }
        
        var courseMenu = MenuBuilder.MenuBuilder.CreateCourseMenu(this,studentCoursesList);

        await MenuRunner.RunMenuAsync(courseMenu, "[yellow] Moji kolegiji[/]");


    }
    
    public async Task ShowCourseSubmenuAsync(CourseResponse course)
    {
        var courseSubmenu = MenuBuilder.MenuBuilder.CreateCourseSubmenu(this, course.CourseId);

        await MenuRunner.RunMenuAsync(courseSubmenu, "[yellow] Kolegij screen[/]");
    }

    public async Task ShowCourseNotificationsAsync(int courseId)
    {
        var notifications = await _courseActions.GetAllNotificationsAsync(courseId,RoleEnum.Student);
        var notificationList = notifications.ToList();
        
        if (notificationList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red bold]Ne postoje dostupne obavijesti.Izlazak...[/]");
            return;
        }
        
        Writer.Course.NotificationWriter(notificationList);

        ConsoleHelper.ScreenExit(1500);
    }
    
    public async Task ShowCourseMaterialsAsync(int courseId)
    {
        
        var materials = await _courseActions.GetAllMaterialsAsync(courseId);
        var materialList = materials.ToList();
        
        if (materialList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red bold]Ne postoje dostupni materijali.Izlazak...[/]");
            return;
        }
        
        Writer.Course.MaterialsWriter(materialList);

        ConsoleHelper.ScreenExit(1500); 
    }
}