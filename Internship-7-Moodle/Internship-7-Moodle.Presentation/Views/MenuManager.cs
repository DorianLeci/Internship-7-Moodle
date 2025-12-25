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
             var emailResult = await FieldPrompt.PromptWithValidation(ShowExitMenu,"Unesi email",
                email => UserPromptFunctions.EmailCheck(email));

            if (emailResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var passwordResult = await FieldPrompt.PromptWithValidation(ShowExitMenu,"Unesi lozinku",
                password =>UserPromptFunctions.PasswordCheck(password));

            if (passwordResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var confirmPasswordResult=await FieldPrompt.PromptWithValidation(ShowExitMenu,
                "Unesi lozinku ponovno",confirmPassword=>UserPromptFunctions.ConfirmPasswordCheck(confirmPassword,passwordResult.Value));
            
            if (confirmPasswordResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;
            }
            
            var firstNameResult =await FieldPrompt.PromptWithValidation(ShowExitMenu,"Unesi ime",firstName=>UserPromptFunctions.NameCheck(firstName));

            if (firstNameResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;           
            }


            var lastNameResult = await FieldPrompt.PromptWithValidation(ShowExitMenu, "Unesi prezime",
                lastName => UserPromptFunctions.NameCheck(lastName));
               
            if (lastNameResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;           
            }


            var birthDateResult = await FieldPrompt.PromptWithValidation(ShowExitMenu, "Unesi datum rođenja",
                birthDate => UserPromptFunctions.BirthDateCheck(birthDate));
            
            if (birthDateResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;           
            }

            
            var genderResult = await FieldPrompt.PromptWithValidation(ShowExitMenu,"Unesi spol (M,F)", gender => UserPromptFunctions.GenderCheck(gender),allowEmpty:true);
            
            if (genderResult.IsCancelled)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;           
            }

            var isCaptchaSuccessful=await ShowCaptchaMenu();

            if (!isCaptchaSuccessful)
            {
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;                       
            }
            
            var response=await _userActions.RegisterUserAsync(firstNameResult.Value,lastNameResult.Value,birthDateResult.Value!.Value,emailResult.Value,genderResult.Value,passwordResult.Value,RoleEnum.Student);
            
            var isUserRegistered=Writer.RegisterUserWriter(response);

            if (!isUserRegistered)
            {
                var isRegistrationRequested = await ShowRetryMenu();
                if (isRegistrationRequested) continue;
                ConsoleHelper.ClearAndSleep(registrationExit);
                return;

            }

            ConsoleHelper.ClearAndSleep(1000,registrationSuccess);
        }


    }


    private async Task<bool> ShowExitMenu()
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

    private async Task<bool> ShowRetryMenu()
    {
        var retryMenu=MenuBuilder.CreateRetryMenu(this);
        
        var title = "[yellow]Odaberi[/]";
        var titlePanel=new Panel(title)
        {
            Padding = new Padding(1, 1, 1, 1),
            Border = BoxBorder.None
        };
        AnsiConsole.Write(titlePanel);
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .AddChoices(retryMenu.Keys));

        return await retryMenu[choice]();     
        
        
    }

    private async Task<bool> ShowCaptchaMenu()
    {
        var captchaString = CaptchaService.GenerateCaptcha();
        
        var isCaptchaValid = await FieldPrompt.PromptWithValidation(ShowExitMenu, 
            $"[white on DarkBlue]{captchaString}[/]\nUnesi captcha prikazan na ekranu",
            input=>CaptchaService.IsCaptchaValid(input)? PresentationValidationResult<string>.Success():PresentationValidationResult<string>.Error("Unesena captcha se ne podudara s prikazanom"));

        return isCaptchaValid.Successful;
    }
}