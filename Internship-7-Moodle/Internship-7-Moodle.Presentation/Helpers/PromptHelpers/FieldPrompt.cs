using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.InputValidation;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.PromptHelpers;

public static class FieldPrompt
{
    public static async Task<PresentationValidationResult<T?>> PromptWithValidation<T>(Func<Task<bool>> showExitMenu,string message,
        Func<string, PresentationValidationResult<T?>> validationFunc, bool allowEmpty = false) where T : struct
    {
        while (true)
        {
            ConsoleHelper.SleepAndClear();

            var prompt = new TextPrompt<string>($"{message}: ");

            if (allowEmpty)
                prompt.AllowEmpty();

            var input = AnsiConsole.Prompt(prompt);

            var result = validationFunc(input);
            if (result.Successful)
                return result;

            AnsiConsole.MarkupLine(result.Message ?? "[red]Neispravan unos[/]");
            
            var isExitChosen=await showExitMenu();
            if (isExitChosen)
                return PresentationValidationResult<T?>.Cancelled();

        }
    }

    public static async Task<PresentationValidationResult<T>> PromptWithValidation<T>(Func<Task<bool>> showExitMenu,string message,
        Func<string, PresentationValidationResult<T>> validationFunc, bool allowEmpty = false,bool hidden=false) where T : class
    {
        while (true)
        {
            ConsoleHelper.SleepAndClear();

            var prompt = new TextPrompt<string>($"{message}: ");

            if (allowEmpty)
                prompt.AllowEmpty();

            if (hidden)
                prompt.Secret();

            var input = AnsiConsole.Prompt(prompt);

            var result = validationFunc(input);
            if (result.Successful)
            {
                return result;
            }


            AnsiConsole.MarkupLine(result.Message ?? "[red]Neispravan unos[/]");

            
            var isExitChosen=await showExitMenu();
            if (isExitChosen)
                return PresentationValidationResult<T>.Cancelled();

        }
    }

    public static PresentationValidationResult<T> MessageContentValidation<T>(string message, Func<string, PresentationValidationResult<T>> validationFunc)
    {
        
        var prompt = new TextPrompt<string>($"{message}: ");   
        var input = AnsiConsole.Prompt(prompt);
        
        var result = validationFunc(input);
        
        return result;
        
    }
    
    

}