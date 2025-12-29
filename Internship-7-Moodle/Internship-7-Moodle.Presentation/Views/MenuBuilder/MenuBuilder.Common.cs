using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Views.Common;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.MenuBuilder;

public partial class MenuBuilder
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
    
    public static Dictionary<string, Func<Task<bool>>> CreateChoiceMenu(MenuManager menuManager,(string message,bool value) confirm,(string message,bool value) quit)
    {
        return new MenuBuilder()
            .AddChoice(confirm.message,()=>confirm.value)
            .AddChoice(quit.message,()=>quit.value)
            .ReturnDictionary();
    }
    
    private MenuBuilder AddCommon(BaseMainMenuManager manager)
    {
        AddChoice("Privatni chat", async () => { await manager.ShowPrivateChatMenuAsync(); return false; });
        
        AddChoice("Odjava", () =>
        {
            AnsiConsole.MarkupLine("[blue]Odjava...[/]");
            ConsoleHelper.ClearAndSleep(2000);
            return true;
        });

        return this;
    }

    private MenuBuilder AddMenuExit()
    {
        AddChoice("Izlazak iz izbornika", () =>
        {
            ConsoleHelper.ClearAndSleep(1000,"[blue]Izlazak...[/]");
            return true;
        });

        return this;
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
    
    public static Dictionary<string,Func<Task<bool>>> CreatePrivateChatMenu(BaseMainMenuManager manager)
    {
        return new MenuBuilder()
            .AddChoice("Nova poruka", async () => { await manager.ShowNewMessageMenuAsync(); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateNewMessageMenu(BaseMainMenuManager manager)
    {
        return new MenuBuilder()
            .AddChoice("Svi korisnici", async () => { await manager.ShowUsersWithoutChatAsync(); return false; })
            .AddChoice("Studenti", async () => { await manager.ShowUsersWithoutChatAsync(RoleEnum.Student); return false; })
            .AddChoice("Profesori", async () => { await manager.ShowUsersWithoutChatAsync(RoleEnum.Professor); return false; })
            .AddChoice("Administratori", async () => { await manager.ShowUsersWithoutChatAsync(RoleEnum.Admin); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateUsersWithoutChatMenu(BaseMainMenuManager manager,List <UserResponse> users)
    {
        var builder = new MenuBuilder();
        builder.AddMenuExit();
        
        foreach (var user in users)
        {
            var stringKey = $"{user.Id}-{user.FirstName} {user.LastName}-{user.RoleName}";
            builder.AddChoice(stringKey,async () => { await manager.OpenPrivateChatAsync(user.Id); return false; });
        }

        return builder.ReturnDictionary();

    }

    
    
}