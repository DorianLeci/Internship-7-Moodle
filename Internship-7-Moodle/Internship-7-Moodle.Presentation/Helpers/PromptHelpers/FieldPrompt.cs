using Figgle;
using Figgle.Fonts;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.InputValidation;
using Internship_7_Moodle.Presentation.Service;
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

            var prompt = new TextPrompt<string>($"[bold]{message}:[/] ");

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

            var prompt = new TextPrompt<string>($"[bold]{message}:[/] ");

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
    
    public static async Task<PresentationValidationResult<T>> PromptWithCaptchaValidation<T>(Func<Task<bool>> showExitMenu,string message,
        Func<string, PresentationValidationResult<T>> validationFunc) where T : class
    {
        
        var fontPath=Path.Combine(AppContext.BaseDirectory, "Fonts", "bubble.flf");
        while (true)
        {
            ConsoleHelper.SleepAndClear();

            var captchaString = CaptchaService.GenerateCaptcha();

            var captchaMarkup = new Markup($"[bold yellow italic]{captchaString}[/]");
            captchaMarkup.Justification = Justify.Center;
            
            AnsiConsole.Write(
                new Panel(captchaMarkup)
                    .Header(" CAPTCHA ", Justify.Center)
                    .BorderColor(Color.Grey)
                    .Padding(1, 1)
                    .Expand()
                
            );

            
            var prompt = new TextPrompt<string>($"[bold]{message}:[/] ");
            

            var input = AnsiConsole.Prompt(prompt);

            var result = validationFunc(input);
            if (result.Successful)
            {
                AnsiConsole.MarkupLine("[rgb(0,255,0) bold]\nUspješan unos captche[/]");
                return result;
            }


            AnsiConsole.MarkupLine(result.Message ?? "[red]Neispravan unos[/]");

            
            var isExitChosen=await showExitMenu();
            if (isExitChosen)
                return PresentationValidationResult<T>.Cancelled();

        }
    }
    

}