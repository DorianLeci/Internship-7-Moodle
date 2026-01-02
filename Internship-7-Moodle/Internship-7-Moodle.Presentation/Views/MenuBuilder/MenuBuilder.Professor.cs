using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    public static Dictionary<string, Func<Task<bool>>> CreateProfessorMenu(ProfessorMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Moji kolegiji", async () => { await mainMenuManager.ShowCourseMenuAsync(true); return false; })
            .AddChoice("Upravljanje kolegijima", async () => { await mainMenuManager.ShowCourseMenuAsync(false); return false; })
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
    
    public static Dictionary<string, Func<Task<bool>>> CreateCourseManagementScreen(ProfessorMainMenuManager mainMenuManager,int courseId)
    {
        return new MenuBuilder()
            .AddChoice("Dodaj studenta na kolegij", async () => { await mainMenuManager.ShowStudentsToAdd(courseId); return false; })
            .AddChoice("Dodaj obavijest", async () => { await mainMenuManager.HandleCourseNotificationPublish(courseId); return false; })
            .AddChoice("Dodaj materijal", async () => { await mainMenuManager.HandleCourseMaterialPublish(courseId); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }
    
    public static Dictionary<string, Func<Task<bool>>> CreateStudentsToAddMenu(ProfessorMainMenuManager mainMenuManager,List <UserResponse> students,int courseId)
    {
        var builder = new MenuBuilder();
        builder.AddMenuExit();
        
        foreach (var student in students)
        {
            var currentStudent = student; 
            var stringKey = $"{currentStudent.Id}-{currentStudent.FullName}";
            builder.AddChoice(stringKey,async () => { await mainMenuManager.HandleStudentAddingToCourse(courseId,currentStudent.Id); return false; });
        }

        return builder.ReturnDictionary();

    }
    
    
}