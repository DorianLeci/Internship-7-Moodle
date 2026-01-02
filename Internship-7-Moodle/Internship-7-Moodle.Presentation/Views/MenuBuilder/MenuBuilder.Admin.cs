using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    public static Dictionary<string, Func<Task<bool>>> CreateAdminMenu(AdminMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Brisanje korisnika", async () => { await mainMenuManager.ShowDeleteUserMenuAsync(); return false; })
            .AddCommon(mainMenuManager)  
            .ReturnDictionary();
    }   

}