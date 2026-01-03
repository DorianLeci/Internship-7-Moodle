using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Views.Common;

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
    
    public static Dictionary<string, Func<Task<bool>>> CreateChoiceMenu((string message,bool value) confirm,(string message,bool value) quit)
    {
        return new MenuBuilder()
            .AddChoice(confirm.message,()=>confirm.value)
            .AddChoice(quit.message,()=>quit.value)
            .ReturnDictionary();
    }
    
    public static Dictionary<string, Func<Task<bool>>> CreateChoiceMenu(BaseMainMenuManager menuManager,(string message,bool value) confirm,(string message,bool value) quit)
    {
        return new MenuBuilder()
            .AddChoice(confirm.message,()=>confirm.value)
            .AddChoice(quit.message,()=>quit.value)
            .ReturnDictionary();
    }

    
    private MenuBuilder AddCommon(BaseMainMenuManager manager)
    {
        AddChoice("Privatni chat", async () => { await manager.ChatFeature.ShowPrivateChatMenuAsync(); return false; });
        
        AddChoice("Odjava", () =>
        {
            ConsoleHelper.SleepAndClear(2000,"[blue bold]Odjava...[/]");
            return true;
        });

        return this;
    }

    private MenuBuilder AddMenuExit()
    {
        AddChoice("Izlazak iz izbornika", () =>
        {
            ConsoleHelper.SleepAndClear(1000,"[blue bold]Izlazak...[/]");
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
            .AddChoice("Izlaz iz aplikacije", ()=> true)
            
            .ReturnDictionary();
    }
    
    public static Dictionary<string,Func<Task<bool>>> CreatePrivateChatMenu(ChatFeature chatFeature)
    {
        return new MenuBuilder()
            .AddChoice("Nova poruka", async () => { await chatFeature.ShowConversationMenuAsync(true," [yellow]Korisnici s kojima još nisi komunicirao[/]"); return false; })
            .AddChoice("Moji razgovori",async()=>{await chatFeature.ShowConversationMenuAsync(false," [yellow]Moji razgovori[/]"); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateConversationMenu(ChatFeature chatFeature,bool withoutChat,string title)
    {
        return new MenuBuilder()
            .AddChoice("Svi korisnici", async () => { await chatFeature.ShowUsersToChatWithAsync(withoutChat:withoutChat,title:title); return false; })
            .AddChoice("Studenti", async () => { await chatFeature.ShowUsersToChatWithAsync(withoutChat,title,RoleEnum.Student); return false; })
            .AddChoice("Profesori", async () => { await chatFeature.ShowUsersToChatWithAsync(withoutChat,title,RoleEnum.Professor); return false; })
            .AddChoice("Administratori", async () => { await chatFeature.ShowUsersToChatWithAsync(withoutChat,title,RoleEnum.Admin); return false; })
            .AddMenuExit()
            .ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateUsersToChatWithMenu(ChatFeature chatFeature,List <UserResponse> users)
    {
        var builder = new MenuBuilder();
        builder.AddMenuExit();
        
        foreach (var user in users)
        {
            var stringKey = $"{user.Id}-{user.FullName}-{user.RoleNameCroatian}";
            builder.AddChoice(stringKey,async () => { await chatFeature.OpenPrivateChatAsync(user.Id); return false; });
        }

        return builder.ReturnDictionary();

    }

    
    
}