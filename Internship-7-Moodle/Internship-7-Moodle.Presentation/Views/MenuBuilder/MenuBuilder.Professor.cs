using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    public static Dictionary<string, Func<Task<bool>>> CreateProfessorMenu(ProfessorMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Moji kolegiji", async () => { await mainMenuManager.ShowCourseMenuAsync(mainMenuManager.Id,true); return false; })
            .AddCommon(mainMenuManager)  
            .ReturnDictionary();
    }   
    
    public static Dictionary<string, Func<Task<bool>>> CreateCourseMenu(ProfessorMainMenuManager mainMenuManager,List<CourseResponse> list,bool isMyCourseSubmenu)
    {
        var builder = new MenuBuilder();

        foreach (var course in list)
        {
            var stringKey = $"{course.CourseName} - ({course.Ects} ECTS)";
            builder.AddChoice(stringKey, async () => {await mainMenuManager.ShowCourseSubmenuAsync(course,isMyCourseSubmenu); return false;});
        }
        
        return builder
            .AddMenuExit()
            .ReturnDictionary();
    }
    
    public static Dictionary<string, Func<Task<bool>>> CreateCourseScreen(ProfessorMainMenuManager mainMenuManager,int courseId)
    {
        return new MenuBuilder()
            .AddChoice("Pregled studenata na kolegiju", async () => { await mainMenuManager.ShowAllStudentsEnrolled(courseId); return false; })
            .AddChoice("Obavijesti",async()=>{await mainMenuManager.ShowCourseNotificationsAsync(courseId); return false; })
            .AddChoice("Materijali", async () => { await mainMenuManager.ShowCourseMaterialsAsync(courseId); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }
    
    
}