using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Views.Admin;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
{
    public static Dictionary<string, Func<Task<bool>>> CreateAdminMenu(AdminMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Brisanje korisnika", async () => { await mainMenuManager.ShowUserDeletionMenuAsync("[yellow bold] Brisanje korisnika[/]",AdminMenuAction.Delete); return false; })
            .AddChoice("Promjena uloge", async () => { await mainMenuManager.ShowUserRoleChangeMenuAsync("[yellow bold] Promjena uloge[/]",AdminMenuAction.ChangeRole); return false; })
            .AddChoice("Promjena emaila", async () => { await mainMenuManager.ShowUserRoleChangeMenuAsync("[yellow bold] Promjena emaila[/]",AdminMenuAction.ChangeEmail); return false; })
            .AddChoice("Statistika", async () => { await mainMenuManager.ShowStatisticsMenuAsync("[yellow bold] Statistika[/]"); return false; })
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
            AdminMenuAction.ChangeEmail => mainMenuManager.HandleUserEmailChangeAsync,
            _ => throw new ArgumentOutOfRangeException(nameof(action), "Nepoznata akcija")
        };
        
        foreach (var user in users)
        {
            var stringKey = $"{user.Id}-{user.FullName}-{user.RoleNameCroatian}";
            builder.AddChoice(stringKey,async () => { await functionToCall(user.Id); return false; });
        }

        return builder.ReturnDictionary();

    }
    
    public static Dictionary<string, Func<Task<bool>>> CreateStatisticsMenu(AdminMainMenuManager mainMenuManager)
    {
        return new MenuBuilder()
            .AddChoice("Broj registriranih korisnika po ulogama", async () => 
                {await mainMenuManager.ShowMetricsMenuAsync(StatisticsMenuAction.UsersByRole,"[yellow bold] Broj registriranih korisnika po ulogama[/]"); return false; })
            
            .AddChoice("Broj kolegija", async () => 
                {await mainMenuManager.ShowMetricsMenuAsync(StatisticsMenuAction.CoursesCount,"[yellow bold] Broj kolegija[/]"); return false; })
            
            .AddChoice("Top 3 kolegija po broju upisanih studenata", async () => 
                {await mainMenuManager.ShowMetricsMenuAsync(StatisticsMenuAction.TopCoursesByStudents,"[yellow bold] Top 3 kolegija po broju upisanih studenata[/]"); return false; })
            
            .AddChoice("Top 3 korisnika po broju poslanih poruka", async () => 
                {await mainMenuManager.ShowMetricsMenuAsync(StatisticsMenuAction.TopUsersByMessages,"[yellow bold] Top 3 kolegija po broju upsanih studenata[/]"); return false; })
            
            .AddMenuExit()
            .ReturnDictionary();
    }
    
    public static Dictionary<string, Func<Task<bool>>> CreateMetricsMenu(AdminMainMenuManager mainMenuManager,StatisticsMenuAction action)
    {
        Func<PeriodEnum,Task> functionToCall = action switch
        {
            StatisticsMenuAction.UsersByRole=>mainMenuManager.ShowRegisteredUserCountByRoleAsync,
            StatisticsMenuAction.CoursesCount=>mainMenuManager.ShowCourseCountAsync,
            StatisticsMenuAction.TopCoursesByStudents=>mainMenuManager.ShowTopCoursesByEnrollmentAsync,
            StatisticsMenuAction.TopUsersByMessages=>mainMenuManager.ShowTopUsersByMsgSentAsync,
            _ => throw new ArgumentOutOfRangeException(nameof(action), "Nepoznata akcija")
        };
        
        return new MenuBuilder()
            .AddChoice("Današnji dan", async () => { await functionToCall(PeriodEnum.Today); return false; })
            .AddChoice("Trenutni mjesec", async () => { await functionToCall(PeriodEnum.ThisMonth); return false; })
            .AddChoice("Ukupno", async () => { await functionToCall(PeriodEnum.Total); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }


    
}