using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    public static Dictionary<string, Func<Task<bool>>> CreateAdminMenu(AdminMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Brisanje korisnika", async () => { await mainMenuManager.ShowUserDeletionMenuAsync("[yellow] Brisanje korisnika[/]"); return false; })
            .AddCommon(mainMenuManager)  
            .ReturnDictionary();
    }   
    
    public static Dictionary<string, Func<Task<bool>>> CreateUserDeletionMenu(AdminMainMenuManager mainMenuManager,string title)
    {
        return new MenuBuilder()
            .AddChoice("Svi korisnici", async () => { await mainMenuManager.ShowUsersToDeleteAsync(title:title); return false; })
            .AddChoice("Studenti", async () => { await mainMenuManager.ShowUsersToDeleteAsync(title: title, RoleEnum.Student); return false; })
            .AddChoice("Profesori", async () => { await mainMenuManager.ShowUsersToDeleteAsync(title:title,RoleEnum.Professor); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }
    
    public static Dictionary<string, Func<Task<bool>>> CreateUsersToDeleteMenu(AdminMainMenuManager mainMenuManager,List <UserResponse> users)
    {
        var builder = new MenuBuilder();
        builder.AddMenuExit();
        
        foreach (var user in users)
        {
            var stringKey = $"{user.Id}-{user.FullName}-{user.RoleNameCroatian}";
            builder.AddChoice(stringKey,async () => { await mainMenuManager.HandleUserDeleteAsync(user.Id); return false; });
        }

        return builder.ReturnDictionary();

    }
    
}