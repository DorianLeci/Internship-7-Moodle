using Internship_7_Moodle.Application.Common.Model;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Helpers.Writers;

public static partial class Writer
{
    public static class Common
    {
        public static void ErrorWriter<T>(AppResult<T> appResult,string headerMessage,string? markupMessage=null) where T:class
        {
            var errorMessages=string.Join("\n",appResult.Errors.Select(e => $"[red]-{e.Message}[/]"));
            
            AnsiConsole.Write(new Panel(errorMessages)
            {
                Header = new PanelHeader(headerMessage,Justify.Center),
                Border=BoxBorder.Rounded
            });
        
            if(markupMessage!=null)
                AnsiConsole.MarkupLine(markupMessage);
        }
    

        
    }
    
    
}