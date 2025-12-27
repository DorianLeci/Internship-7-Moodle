using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    
    public static Dictionary<string, Func<Task<bool>>> CreateStudentMenu(StudentMainMenuManager mainMenuManager)
    {
        var builder = new MenuBuilder();
        
        builder.AddChoice("Moji kolegiji", async () => { await mainMenuManager.ShowCourseMenuAsync(mainMenuManager.Id); return false; });

        AddCommon(builder, mainMenuManager);
        
        return builder.ReturnDictionary();
    }   
    public static Dictionary<string, Func<Task<bool>>> CreateCourseMenu(StudentMainMenuManager mainMenuManager,List<StudentCourseResponse> list)
    {
        var builder = new MenuBuilder();

        foreach (var course in list)
        {
            var stringKey = $"{course.CourseName} - ({course.Ects} ECTS) - Profesor: {course.ProfessorName}";
            builder.AddChoice(stringKey, async () => {await mainMenuManager.ShowCourseSubmenuAsync(course); return false;});
        }

        builder.AddChoice("Izlazak iz izbornika", () =>
        {
            AnsiConsole.MarkupLine("[blue]Izlazak...[/]");
            ConsoleHelper.ClearAndSleep(2000);
            return true;
        });

        return builder.ReturnDictionary();

    }

    public static Dictionary<string, Func<Task<bool>>> CreateCourseSubmenu(StudentMainMenuManager mainMenuManager,int courseId)
    {
        return new MenuBuilder()
            .AddChoice("Obavijesti", async () =>
            {
                await mainMenuManager.ShowCourseNotificationsAsync(courseId);
                return false;
            })
            .AddChoice("Materijali", async () =>
            {
                await mainMenuManager.ShowCourseMaterialsAsync(courseId);
                return false;
            })
            .AddChoice("Izlazak iz izbornika", () =>
            {
                AnsiConsole.MarkupLine("[blue]Izlazak...[/]");
                ConsoleHelper.ClearAndSleep(1000);
                return true;
            })
            .ReturnDictionary();
    }

}