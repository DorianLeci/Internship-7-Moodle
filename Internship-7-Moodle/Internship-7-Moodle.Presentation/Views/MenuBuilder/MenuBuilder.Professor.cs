using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    public static Dictionary<string, Func<Task<bool>>> CreateStudentMenu(ProfessorMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Upravljanje kolegija", async () => { await mainMenuManager.ShowCourseManagementMenu(mainMenuManager.Id); return false; })
            .AddCommon(mainMenuManager)  
            .ReturnDictionary();
    }   
}