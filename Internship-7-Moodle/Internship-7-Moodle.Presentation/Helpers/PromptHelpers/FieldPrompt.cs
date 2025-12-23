using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.InputValidation;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.PromptHelpers;

public static class FieldPrompt
{
    public static PresentationValidationResult<T?> PromptWithValidation<T>(string message,
        Func<string, PresentationValidationResult<T?>> validationFunc, bool allowEmpty = false) where T : struct
    {
        while (true)
        {
            ConsoleHelper.ClearAndSleep();

            var prompt = new TextPrompt<string>($"{message}: ");

            if (allowEmpty)
                prompt.AllowEmpty();

            var input = AnsiConsole.Prompt(prompt);

            var result = validationFunc(input);
            if (result.Successful)
                return result;

            AnsiConsole.MarkupLine(result.Message ?? "[red]Neispravan unos[/]");
            AnsiConsole.MarkupLine(
                "[red]Pritisni esc tipku ako želiš odustati od registracije,a bilo koju drugu ako želiš ponovno pokušati.[/]");

            var exitInput = Console.ReadKey(intercept: true).Key;
            if (exitInput == ConsoleKey.Escape)
                return PresentationValidationResult<T?>.Cancelled();
        }
    }

    public static PresentationValidationResult<T> PromptWithValidation<T>(string message,
        Func<string, PresentationValidationResult<T>> validationFunc, bool allowEmpty = false) where T : class
    {
        while (true)
        {
            ConsoleHelper.ClearAndSleep();

            var prompt = new TextPrompt<string>($"{message}: ");

            if (allowEmpty)
                prompt.AllowEmpty();

            var input = AnsiConsole.Prompt(prompt);

            var result = validationFunc(input);
            if (result.Successful)
            {
                AnsiConsole.MarkupLine($"Value: {result.Value}");
                return result;
            }


            AnsiConsole.MarkupLine(result.Message ?? "[red]Neispravan unos[/]");
            AnsiConsole.MarkupLine(
                "[red]Pritisni esc tipku ako želiš odustati od registracije,a bilo koju drugu ako želiš ponovno pokušati.[/]");

            var exitInput = Console.ReadKey(intercept: true).Key;
            if (exitInput == ConsoleKey.Escape)
                return PresentationValidationResult<T>.Cancelled();

        }
    }

}