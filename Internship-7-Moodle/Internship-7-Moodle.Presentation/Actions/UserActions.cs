using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Presentation.Helper;
using Internship_7_Moodle.Presentation.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Actions;

public class UserActions
{
    private readonly IMediator _mediator;

    public UserActions(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task RegisterUserAsync()
    {
        var email=AnsiConsole.Prompt(
            new TextPrompt<string>("Unesi email: ")
                
                .Validate(email =>
                {
                    if(string.IsNullOrEmpty(email))
                        return ValidationResult.Error("[red]Email je obavezno polje[/]");

                    return EmailFormatCheck.IsEmailValid(email)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]Email nije u ispravnom formatu[/]");
                }

                ));
            
        var firstName = AnsiConsole.Prompt(
            new TextPrompt<string>("Unesi ime: ")
                .Validate(firstName =>
                    {
                        if(string.IsNullOrEmpty(firstName))
                            return ValidationResult.Error("[red]Ime je obavezno polje[/]");
                        
                        return NameFormatCheck.IsNameValid(firstName)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Ime nije u ispravnom formatu[/]");
                    }

                ));
        
        var lastName= AnsiConsole.Prompt(
            new TextPrompt<string>("Unesi prezime: ")
                .Validate(lastName =>
                {
                    if(string.IsNullOrEmpty(lastName))
                        return ValidationResult.Error("[red]Prezime je obavezno polje[/]");

                    return NameFormatCheck.IsNameValid(lastName)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]Prezime nije u ispravnom formatu[/]");
                }

                ));

        var birthDate = AnsiConsole.Prompt(
            new TextPrompt<string>("Unesi datum rođenja: (yyyy-MM-dd)")
                .AllowEmpty()
                .Validate(birthDate =>
                    {
                        if (string.IsNullOrEmpty(birthDate))
                            return ValidationResult.Success();

                        return DateFormatCheck.IsDateValid(birthDate)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Datum rođenja nije u ispravnom formatu[/]");
                    }

                ));
        
        var gender= AnsiConsole.Prompt(
            new TextPrompt<string>("Unesi spol: (M,F)")
                .AllowEmpty()
                .Validate(gender =>
                    {
                        if (string.IsNullOrEmpty(birthDate))
                            return ValidationResult.Success();

                        return DateFormatCheck.IsDateValid(birthDate)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Datum rođenja nije u ispravnom formatu[/]");
                    }

                ));
        


    }
}