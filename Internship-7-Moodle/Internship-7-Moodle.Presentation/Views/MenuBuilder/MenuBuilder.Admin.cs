using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Views.Admin;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    public static Dictionary<string, Func<Task<bool>>> CreateAdminMenu(AdminMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Brisanje korisnika", async () => { await mainMenuManager.ShowUserDeletionMenuAsync("[yellow] Brisanje korisnika[/]",AdminMenuAction.Delete); return false; })
            .AddChoice("Promjena uloge", async () => { await mainMenuManager.ShowUserRoleChangeMenuAsync("[yellow] Promjena uloge[/]",AdminMenuAction.ChangeRole); return false; })
            .AddCommon(mainMenuManager)  
            .ReturnDictionary();
    }   
    
    public static Dictionary<string, Func<Task<bool>>> CreateAdminActionMenu(AdminMainMenuManager mainMenuManager,string title,AdminMenuAction action)
    {
        return new MenuBuilder()
            .AddChoice("Svi korisnici", async () => { await mainMenuManager.ShowUsersAsync(title:title,action); return false; })
            .AddChoice("Studenti", async () => { await mainMenuManager.ShowUsersAsync(title: title, action,RoleEnum.Student); return false; })
            .AddChoice("Profesori", async () => { await mainMenuManager.ShowUsersAsync(title:title,action,RoleEnum.Professor); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }
    
    
    public static Dictionary<string, Func<Task<bool>>> CreateUsersMenu(AdminMainMenuManager mainMenuManager,List <UserResponse> users,AdminMenuAction action)
    {
        var builder = new MenuBuilder();
        builder.AddMenuExit();
        
        Func<int,Task> functionToCall = action switch
        {
            AdminMenuAction.Delete => mainMenuManager.HandleUserDeleteAsync,
            AdminMenuAction.ChangeRole => mainMenuManager.HandleUserRoleChangeAsync,
            AdminMenuAction.ChangeEmail => mainMenuManager.HandleUserRoleChangeAsync,
            _ => throw new ArgumentOutOfRangeException(nameof(action), "Nepoznata akcija")
        };
        
        foreach (var user in users)
        {
            var stringKey = $"{user.Id}-{user.FullName}-{user.RoleNameCroatian}";
            builder.AddChoice(stringKey,async () => { await functionToCall(user.Id); return false; });
        }

        return builder.ReturnDictionary();

    }
    
}