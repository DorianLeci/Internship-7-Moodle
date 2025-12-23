using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.FormatCheck;
using Internship_7_Moodle.Presentation.Helpers.PromptHelpers;
using Internship_7_Moodle.Presentation.InputValidation;
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
        
        var menuActions = new Dictionary<string, Func<Task<bool>>>
        {
            ["Register"]=async() => {await HandleRegisterUserAsync(); return false; },
            ["Exit"]=async()=>{ Console.WriteLine("Exiting application..."); return true; }
        };

        while (!exitRequested)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>().Title("[red]Main Menu[/]")
                    .AddChoices(menuActions.Keys));

            exitRequested = await menuActions[choice]();            
        }

    }

    private async Task HandleRegisterUserAsync()
    {
        const string registrationExit="[blue]Izlazak iz registracije[/]";
        
        var email = FieldPrompt.PromptWithValidation("Unesi email",
            email => EmailFormatCheck.IsEmailValid(email) ? PresentationValidationResult<string>.Success(email) : PresentationValidationResult<string>.Error("[red]Email nije u ispravnom formatu[/]"));

        if (email.IsCancelled)
        {
            ConsoleHelper.ClearAndSleep(registrationExit);
            return;
        }
        
        
        var password = FieldPrompt.PromptWithValidation("Unesi lozinku",
            password =>
            {
                var errors=PasswordFormatCheck.IsPasswordValid(password);
                    
                return errors.Count==0 ? PresentationValidationResult<string>.Success(password) : PresentationValidationResult<string>.Error(string.Join("\n",errors));
            });

        if (password.IsCancelled)
        {
            ConsoleHelper.ClearAndSleep(registrationExit);
            return;
        }
        
        
        var firstName =FieldPrompt.PromptWithValidation("Unesi ime",firstName=>
            NameFormatCheck.IsNameValid(firstName) 
                ? PresentationValidationResult<string>.Success(firstName) : PresentationValidationResult<string>.Error("[red]Ime nije u ispravnom formatu.Ne smije imati brojeve ili specijalne znakove[/]"));

        if (firstName.IsCancelled)
        {
            ConsoleHelper.ClearAndSleep(registrationExit);
            return;           
        }
            
        
        var lastName= FieldPrompt.PromptWithValidation("Unesi prezime",lastName=>
            NameFormatCheck.IsNameValid(lastName) 
                ? PresentationValidationResult<string>.Success(lastName) : PresentationValidationResult<string>.Error("[red]Prezime nije u ispravnom formatu.Ne smije imati brojeve ili specijalne znakove[/]"));
        
        if (lastName.IsCancelled)
        {
            ConsoleHelper.ClearAndSleep(registrationExit);
            return;           
        }

        
        var birthDate = FieldPrompt.PromptWithValidation("Unesi datum rođenja", birthDate =>
        {
            if (string.IsNullOrEmpty(birthDate))
                return PresentationValidationResult<DateOnly?>.Success();

            return DateFormatCheck.IsDateValid(birthDate,out var dt)
                ? PresentationValidationResult<DateOnly?>.Success(dt)
                : PresentationValidationResult<DateOnly?>.Error("[red]Datum rođenja nije u ispravnom formatu[/]");
        },allowEmpty:true);
        
        if (birthDate.IsCancelled)
        {
            ConsoleHelper.ClearAndSleep(registrationExit);
            return;           
        }

        
        var gender = FieldPrompt.PromptWithValidation("Unesi spol (M,F)", gender =>
        {
            if (string.IsNullOrEmpty(gender))
                return PresentationValidationResult<GenderEnum?>.Success();

            return GenderFormatCheck.IsGenderValid(gender,out var gd)
                ? PresentationValidationResult<GenderEnum?>.Success(gd)
                : PresentationValidationResult<GenderEnum?>.Error("[red]Spol nije u ispravnom formatu[/]");
        },allowEmpty:true);
        
        if (gender.IsCancelled)
        {
            ConsoleHelper.ClearAndSleep(registrationExit);
            return;           
        }
        
        
        await _userActions.RegisterUserAsync();
    }
}