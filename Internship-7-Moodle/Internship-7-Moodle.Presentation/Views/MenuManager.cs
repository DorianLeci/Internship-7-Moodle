using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.PromptFunctions;
using Internship_7_Moodle.Presentation.Helpers.PromptHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Internship_7_Moodle.Presentation.InputValidation;
using Internship_7_Moodle.Presentation.Service;
using Internship_7_Moodle.Presentation.Views.Common;
using Spectre.Console;
using CaptchaService = Internship_7_Moodle.Presentation.Service.CaptchaService;

namespace Internship_7_Moodle.Presentation.Views;

public sealed class MenuManager
{
    private readonly MenuDependencies.MenuDependencies _menuDependencies;
    private readonly AntiBotService _antiBotService;

    public MenuManager(MenuDependencies.MenuDependencies menuDependencies,AntiBotService antiBotService)
    {
        _menuDependencies = menuDependencies;
        _antiBotService = antiBotService;
    }
    public async Task RunAsync()
    {
        AnsiConsole.Clear();

        var guestMenu = MenuBuilder.MenuBuilder.CreateGuestMenu(this);

        await MenuRunner.RunMenuAsync(guestMenu, "[yellow] Početni izbornik[/]",exitChoice:"Izlaz iz aplikacije");

    }

    public async Task HandleRegisterUserAsync()
    {
        const string registrationExit="[blue bold]Izlazak iz registracije...[/]";

        while (true)
        {
             var emailResult = await FieldPrompt.PromptWithValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(),"Unesi email",
                PromptFunctions.UserRegister.EmailCheck);

            if (emailResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;
            }

            var hidePassword = await ChoiceMenu.ShowChoiceMenuAsync(("Da",true), ("Ne",false), "[yellow]Zeliš li sakriti lozinku[/]");
            
            var passwordResult = await FieldPrompt.PromptWithValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(),"Unesi lozinku",
                PromptFunctions.UserRegister.PasswordCheck,hidden:hidePassword);

            if (passwordResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;
            }
            
            var confirmPasswordResult=await FieldPrompt.PromptWithValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(),
                "Unesi lozinku ponovno",confirmPassword=>PromptFunctions.UserRegister.ConfirmPasswordCheck(confirmPassword,passwordResult.Value),hidden:hidePassword);
            
            if (confirmPasswordResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;
            }
            
            var firstNameResult =await FieldPrompt.PromptWithValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(),"Unesi ime",PromptFunctions.UserRegister.NameCheck);

            if (firstNameResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;           
            }


            var lastNameResult = await FieldPrompt.PromptWithValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(), "Unesi prezime",
                PromptFunctions.UserRegister.NameCheck);
               
            if (lastNameResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;           
            }


            var birthDateResult = await FieldPrompt.PromptWithValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(), "Unesi datum rođenja(yyyy-MM-dd)",
                PromptFunctions.UserRegister.BirthDateCheck);
            
            if (birthDateResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;           
            }

            
            var genderResult = await FieldPrompt.PromptWithValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(),"Unesi spol (M,F)", gender => PromptFunctions.UserRegister.GenderCheck(gender),allowEmpty:true);
            
            if (genderResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;           
            }

            var isCaptchaSuccessful=await ShowCaptchaMenuAsync();

            if (!isCaptchaSuccessful)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;                       
            }
            
            var response=await _menuDependencies.UserActions.RegisterUserAsync(firstNameResult.Value,lastNameResult.Value,birthDateResult.Value!.Value,emailResult.Value,genderResult.Value,passwordResult.Value,RoleEnum.Student);
            
            var isUserRegistered=Writer.Authentication.RegisterUserWriter(response);

            if (!isUserRegistered)
            {
                var isRegistrationRequested = await ChoiceMenu.ShowChoiceMenuAsync(("Pokušaj ponovno",true),("Odustani",false),"[yellow]Želiš li pokušati ponovno?[/]");
                if (isRegistrationRequested) continue;

                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,registrationExit);
                return;

            }
            
            ConsoleHelper.SleepAndClear(2000);
            return;
        }


    }

    public async Task HandleLoginUserAsync()
    {
        const string loginExit="[blue bold]Izlazak iz prijave...[/]";
        
        while (true)
        {
            ConsoleHelper.SleepAndClear();

            var isCancelled=await _antiBotService.ApplyCooldownAsync();
            if (isCancelled)
            {
                ConsoleHelper.SleepAndClear(2000,loginExit);
                return;
            }
            
            var email = AnsiConsole.Prompt(new TextPrompt<string>("[bold]Unesi email:[/]"));

            var hidePassword = await ChoiceMenu.ShowChoiceMenuAsync(("Da", true), ("Ne", false), "[yellow]Zeliš li sakriti lozinku[/]");
            AnsiConsole.Clear();
            
            var passwordPrompt = new TextPrompt<string>("[bold]Unesi lozinku:[/]");
            if (hidePassword)
                passwordPrompt.Secret();
            
            var password = AnsiConsole.Prompt(passwordPrompt);
            
            
            var response = await _menuDependencies.UserActions.LoginUserAsync(email, password);

            var isLoginSuccessful=Writer.Authentication.LoginUserWriter(response);

            if (!isLoginSuccessful)
            {
                _antiBotService.RecordFailedLogin();
                
                var isLoginRequested=await ChoiceMenu.ShowChoiceMenuAsync(("Pokušaj ponovno",true),("Odustani",false),"[yellow]Želiš li pokušati ponovno?[/]");
                if (isLoginRequested) continue;
                
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,loginExit);
                return;
            }
            
            var mainMenu = MainMenuFactory.Create(_menuDependencies,response.Value!.RoleName,response.Value.Id);
            ConsoleHelper.SleepAndClear(4000);
            await mainMenu.RunAsync();
            
            return;
            
        }
        

    }
    
    private async Task<bool> ShowCaptchaMenuAsync()
    {
        var isCaptchaValid = await FieldPrompt.PromptWithCaptchaValidation(()=>ChoiceMenu.ShowChoiceMenuAsync(), 
            "Unesi captcha prikazan na ekranu",
            input=>CaptchaService.IsCaptchaValid(input)? PresentationValidationResult<string>.Success():PresentationValidationResult<string>.Error("[red]\nUnesena captcha se ne podudara s prikazanom[/]"));

        return isCaptchaValid.Successful;
    }
}