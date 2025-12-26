namespace Internship_7_Moodle.Presentation.Views;

public class MenuBuilder
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

    public static Dictionary<string, Func<Task<bool>>> CreateMainMenu(MenuManager menuManager)
    {
        return new MenuBuilder()
            .AddChoice("Registracija", async () =>
                { await menuManager.HandleRegisterUserAsync(); return false; })
            .AddChoice("Prijava", async () =>
                { await menuManager.HandleLoginUserAsync(); return false; })
            .AddChoice("Izlaz iz aplikacije", ()=> {Console.WriteLine("Exiting application..."); return true; })
            
            .ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateExitMenu(MenuManager menuManager)
    {
        return new MenuBuilder()
            .AddChoice("Nastavi",()=>false)
            .AddChoice("Odustani",()=>true)
            .ReturnDictionary();
    }

    public static Dictionary<string, Func<Task<bool>>> CreateRetryMenu(MenuManager menuManager)
    {
        return new MenuBuilder()
            .AddChoice("Pokušaj ponovno",()=>true)
            .AddChoice("Odustani",()=>false)
            .ReturnDictionary();
    }
    
}