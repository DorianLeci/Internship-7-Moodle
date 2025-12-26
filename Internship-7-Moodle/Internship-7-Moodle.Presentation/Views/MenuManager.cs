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
        const string registrationExit="[blue]Izlazak iz registracije[/]";
        const string registrationSuccess = "[green]Uspješna registracija[/]";

        while (true)
        {
             var emailResult = await FieldPrompt.PromptWithValidation(ShowExitMenuAsync,"Unesi email",
                email => UserPromptFunctions.EmailCheck(email));

            if (emailResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var passwordResult = await FieldPrompt.PromptWithValidation(ShowExitMenuAsync,"Unesi lozinku",
                password =>UserPromptFunctions.PasswordCheck(password));

            if (passwordResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var confirmPasswordResult=await FieldPrompt.PromptWithValidation(ShowExitMenuAsync,
                "Unesi lozinku ponovno",confirmPassword=>UserPromptFunctions.ConfirmPasswordCheck(confirmPassword,passwordResult.Value));
            
            if (confirmPasswordResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var firstNameResult =await FieldPrompt.PromptWithValidation(ShowExitMenuAsync,"Unesi ime",firstName=>UserPromptFunctions.NameCheck(firstName));

            if (firstNameResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;           
            }


            var lastNameResult = await FieldPrompt.PromptWithValidation(ShowExitMenuAsync, "Unesi prezime",
                lastName => UserPromptFunctions.NameCheck(lastName));
               
            if (lastNameResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;           
            }


            var birthDateResult = await FieldPrompt.PromptWithValidation(ShowExitMenuAsync, "Unesi datum rođenja",
                birthDate => UserPromptFunctions.BirthDateCheck(birthDate));
            
            if (birthDateResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;           
            }

            
            var genderResult = await FieldPrompt.PromptWithValidation(ShowExitMenuAsync,"Unesi spol (M,F)", gender => UserPromptFunctions.GenderCheck(gender),allowEmpty:true);
            
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
                var isRegistrationRequested = await ShowRetryMenuAsync();
                if (isRegistrationRequested) continue;
                ConsoleHelper.ClearAndSleep(2000,registrationExit);
                return;

            }

            ConsoleHelper.ClearAndSleep(2000);
            return;
        }


    }

    public async Task HandleLoginUserAsync()
    {
        const string loginExit="[blue]Izlazak iz prijave[/]";
        const string loginSuccess = "[green]Uspješna prijava[/]";
        const int antiBotDelaySeconds = 30;
        
        while (true)
        {
            ConsoleHelper.ClearAndSleep();
            var email = AnsiConsole.Prompt(new TextPrompt<string>("Unesi email:"));
            var password = AnsiConsole.Prompt(new TextPrompt<string>("Unesi lozinku:"));

            var response = await _userActions.LoginUserAsync(email, password);

            var isLoginSuccessful=Writer.LoginUserWriter(response);

            if (!isLoginSuccessful)
            {
                var isLoginRequested=await ShowRetryMenuAsync();
                if (isLoginRequested)
                {
                    await ConsoleHelper.ShowCountdown(antiBotDelaySeconds);
                    continue;
                }
                ConsoleHelper.ClearAndSleep(2000,loginExit);
                return;
            }
            ConsoleHelper.ClearAndSleep(2000);
            return;
            
        }
        

    }
    private async Task<bool> ShowExitMenuAsync()
    {
        var exitMenu = MenuBuilder.CreateExitMenu(this);

        var title = "[yellow]Želiš li odustati od registracije[/]";
        var titlePanel=new Panel(title)
        {
            Padding = new Padding(1, 1, 1, 1),
            Border = BoxBorder.None
        };
        AnsiConsole.Write(titlePanel);
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices(exitMenu.Keys));

        return await exitMenu[choice]();
    }

    private async Task<bool> ShowRetryMenuAsync()
    {
        var retryMenu=MenuBuilder.CreateRetryMenu(this);
        
        var title = "[yellow]Odaberi[/]";
        var titlePanel=new Panel(title)
        {
            Padding = new Padding(1, 1, 1, 0),
            Border = BoxBorder.None
        };
        AnsiConsole.Write(titlePanel);
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices(retryMenu.Keys));

        return await retryMenu[choice]();     
        
        
    }

    private async Task<bool> ShowCaptchaMenuAsync()
    {
        var captchaString = CaptchaService.GenerateCaptcha();
        
        var isCaptchaValid = await FieldPrompt.PromptWithValidation(ShowExitMenuAsync, 
            $"[white on DarkBlue]{captchaString}[/]\nUnesi captcha prikazan na ekranu",
            input=>CaptchaService.IsCaptchaValid(input)? PresentationValidationResult<string>.Success():PresentationValidationResult<string>.Error("Unesena captcha se ne podudara s prikazanom"));

        return isCaptchaValid.Successful;
    }
}