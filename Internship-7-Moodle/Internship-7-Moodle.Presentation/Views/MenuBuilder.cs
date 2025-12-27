using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views;

public class MenuBuilder
{
    private readonly Dictionary<string, Func<Task<bool>>> _menuOptions = new();
    
    private MenuBuilder AddChoice(string label, Func<Task<bool>> action)
    {
        _menuOptions.Add(label, action);
        return this;
    }
    private MenuBuilder AddChoice(string label, Func<bool> action)
    {
        _menuOptions.Add(label, ()=>Task.FromResult(action()));
        return this;
    }
    
    private Dictionary<string, Func<Task<bool>>> ReturnDictionary()
    {
        return _menuOptions;
    }

    public static Dictionary<string, Func<Task<bool>>> CreateGuestMenu(MenuManager menuManager)
    {
        return new MenuBuilder()
            .AddChoice("Registracija", async () =>
                { await menuManager.HandleRegisterUserAsync(); return false; })
            .AddChoice("Prijava", async () =>
                { await menuManager.HandleLoginUserAsync(); return false; })
            .AddChoice("Izlaz iz aplikacije", ()=>
            {
                AnsiConsole.MarkupLine("[blue]Izlaz iz aplikacije...[/]"); return true; })
            
            .ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateChoiceMenu(MenuManager menuManager,(string message,bool value) confirm,(string message,bool value) quit)
    {
        return new MenuBuilder()
            .AddChoice(confirm.message,()=>confirm.value)
            .AddChoice(quit.message,()=>quit.value)
            .ReturnDictionary();
    }
    
    public static Dictionary<string, Func<Task<bool>>> CreateMainMenu(MainMenuManager menuManager)
    {
        var builder = new MenuBuilder();

        if (menuManager.RoleName == RoleEnum.Student)
            builder.AddChoice("Moji kolegiji", async () =>
            {
                await menuManager.ShowCourseMenuAsync(menuManager.UserId);
                return false;
            });

        builder.AddChoice("Odjava", () =>
        {
            AnsiConsole.MarkupLine("[blue]Odjava...[/]");
            ConsoleHelper.ClearAndSleep(2000);
            return true;
        });
        
        return builder.ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateCourseMenu(MainMenuManager menuManager,List<StudentCourseResponse> list)
    {
        var builder = new MenuBuilder();

        foreach (var course in list)
        {
            var stringKey = $"{course.CourseName} - ({course.Ects} ECTS) - Profesor: {course.ProfessorName}";
            builder.AddChoice(stringKey, async () => {await menuManager.ShowCourseSubmenuAsync(course); return false;});
        }

        builder.AddChoice("Izlazak iz izbornika", () =>
        {
            AnsiConsole.MarkupLine("[blue]Izlazak...[/]");
            ConsoleHelper.ClearAndSleep(2000);
            return true;
        });

        return builder.ReturnDictionary();

    }

    public static Dictionary<string, Func<Task<bool>>> CreateCourseSubmenu(MainMenuManager menuManager,int courseId)
    {
        return new MenuBuilder()
            .AddChoice("Obavijesti", async () =>
            {
                await menuManager.ShowCourseNotificationsAsync(courseId);
                return false;
            })
            .AddChoice("Materijali", async () =>
            {
                await menuManager.ShowCourseMaterialsAsync(courseId);
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