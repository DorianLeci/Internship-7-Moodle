using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;
namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    
    public static Dictionary<string, Func<Task<bool>>> CreateStudentMenu(StudentMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Moji kolegiji", async () => { await mainMenuManager.ShowCourseMenuAsync(mainMenuManager.Id); return false; })
            .AddCommon(mainMenuManager)  
            .ReturnDictionary();
    }   
    public static Dictionary<string, Func<Task<bool>>> CreateCourseMenu(StudentMainMenuManager mainMenuManager,List<CourseResponse> list)
    {
        var builder = new MenuBuilder();

        foreach (var course in list)
        {
            var stringKey = $"{course.CourseName} - ({course.Ects} ECTS) - Profesor: {course.ProfessorName}";
            builder.AddChoice(stringKey, async () => {await mainMenuManager.ShowCourseSubmenuAsync(course); return false;});
        }
        
        return builder
            .AddMenuExit()
            .ReturnDictionary();

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
            .AddMenuExit()
            .ReturnDictionary();
    }

}