using Figgle.Fonts;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Infrastructure.Security;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.FormatCheck;
using Internship_7_Moodle.Presentation.Helpers.PromptFunctions.User;
using Internship_7_Moodle.Presentation.Helpers.PromptHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Internship_7_Moodle.Presentation.InputValidation;
using Npgsql.Internal.Postgres;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views;

public class MenuManager
{
    private readonly UserActions _userActions;

    public MenuManager(UserActions userActions)
    {
        _userActions = userActions;
    }
    public async Task RunAsync()
    {
        bool exitRequested = false;

        var mainMenu = MenuBuilder.CreateMainMenu(this);

        while (!exitRequested)
        {
            var title = "[yellow]Glavni izbornik[/]";
            var titlePanel=new Panel(title)
            {
                Padding = new Padding(1, 1, 1, 1),
                Border = BoxBorder.None
            };
            
            AnsiConsole.Write(titlePanel);
            
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices(mainMenu.Keys));

            exitRequested = await mainMenu[choice]();            
        }

    }

    public async Task HandleRegisterUserAsync()
    {
        const string registrationExit="[blue]Izlazak iz registracije...[/]";

        while (true)
        {
             var emailResult = await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(),"Unesi email",
                email => UserPromptFunctions.EmailCheck(email));

            if (emailResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }

            var hidePassword = await ShowChoiceMenuAsync(("Da",true), ("Ne",false), "[yellow]Zeliš li sakriti lozinku[/]");
            
            var passwordResult = await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(),"Unesi lozinku",
                password =>UserPromptFunctions.PasswordCheck(password),hidden:hidePassword);

            if (passwordResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var confirmPasswordResult=await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(),
                "Unesi lozinku ponovno",confirmPassword=>UserPromptFunctions.ConfirmPasswordCheck(confirmPassword,passwordResult.Value),hidden:hidePassword);
            
            if (confirmPasswordResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var firstNameResult =await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(),"Unesi ime",firstName=>UserPromptFunctions.NameCheck(firstName));

            if (firstNameResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;           
            }


            var lastNameResult = await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(), "Unesi prezime",
                lastName => UserPromptFunctions.NameCheck(lastName));
               
            if (lastNameResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;           
            }


            var birthDateResult = await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(), "Unesi datum rođenja",
                birthDate => UserPromptFunctions.BirthDateCheck(birthDate));
            
            if (birthDateResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;           
            }

            
            var genderResult = await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(),"Unesi spol (M,F)", gender => UserPromptFunctions.GenderCheck(gender),allowEmpty:true);
            
            if (genderResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;           
            }

            var isCaptchaSuccessful=await ShowCaptchaMenuAsync();

            if (!isCaptchaSuccessful)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;                       
            }
            
            var response=await _userActions.RegisterUserAsync(firstNameResult.Value,lastNameResult.Value,birthDateResult.Value!.Value,emailResult.Value,genderResult.Value,passwordResult.Value,RoleEnum.Student);
            
            var isUserRegistered=Writer.RegisterUserWriter(response);

            if (!isUserRegistered)
            {
                var isRegistrationRequested = await ShowChoiceMenuAsync(("Pokušaj ponovno",true),("Odustani",false),"[yellow]Želiš li pokušati ponovno?[/]");
                if (isRegistrationRequested) continue;

                AnsiConsole.Clear();
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;

            }

            ConsoleHelper.ClearAndSleep(2000);
            return;
        }


    }

    public async Task HandleLoginUserAsync()
    {
        const string loginExit="[blue]Izlazak iz prijave...[/]";
        const int antiBotDelaySeconds = 30;
        
        while (true)
        {
            ConsoleHelper.ClearAndSleep();
            
            var email = AnsiConsole.Prompt(new TextPrompt<string>("Unesi email:"));

            var hidePassword = await ShowChoiceMenuAsync(("Da", true), ("Ne", false), "[yellow]Zeliš li sakriti lozinku[/]");
            AnsiConsole.Clear();
            
            var passwordPrompt = new TextPrompt<string>("Unesi lozinku:");
            if (hidePassword)
                passwordPrompt.Secret();
            
            var password = AnsiConsole.Prompt(passwordPrompt);
            
            
            var response = await _userActions.LoginUserAsync(email, password);

            var isLoginSuccessful=Writer.LoginUserWriter(response);

            if (!isLoginSuccessful)
            {
                var isLoginRequested=await ShowChoiceMenuAsync(("Pokušaj ponovno",true),("Odustani",false),"[yellow]Želiš li pokušati ponovno?[/]");
                if (isLoginRequested)
                {
                    await ConsoleHelper.ShowCountdown(antiBotDelaySeconds);
                    continue;
                }
                
                AnsiConsole.Clear();
                ConsoleHelper.ClearAndSleep(2000,loginExit);
                return;
            }
            ConsoleHelper.ClearAndSleep(2000);
            return;
            
        }
        

    }
    private async Task<bool> ShowChoiceMenuAsync((string message,bool value)? confirm=null,(string message,bool value)? quit=null,string title="[yellow]Želiš li odustati od registracije[/]")
    {
        var confirmChoice=confirm ?? ("Nastavi", false);
        var quitChoice= quit ?? ("Odustani", true);
        
        var exitMenu = MenuBuilder.CreateChoiceMenu(this,confirmChoice,quitChoice);
        
        var titlePanel=new Panel(title)
        {
            Padding = new Padding(1, 1, 1, 0),
            Border = BoxBorder.None
        };
        AnsiConsole.Write(titlePanel);
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices(exitMenu.Keys));

        return await exitMenu[choice]();
    }
    
    private async Task<bool> ShowCaptchaMenuAsync()
    {
        var captchaString = CaptchaService.GenerateCaptcha();
        
        var isCaptchaValid = await FieldPrompt.PromptWithValidation(()=>ShowChoiceMenuAsync(), 
            $"[white on DarkBlue]{captchaString}[/]\nUnesi captcha prikazan na ekranu",
            input=>CaptchaService.IsCaptchaValid(input)? PresentationValidationResult<string>.Success():PresentationValidationResult<string>.Error("[red]\nUnesena captcha se ne podudara s prikazanom[/]"));

        return isCaptchaValid.Successful;
    }
}