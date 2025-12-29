using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Presentation.InputValidation;

namespace Internship_7_Moodle.Presentation.Helpers.PromptFunctions;

public static partial class PromptFunctions
{
    public static class Message
    {
        public static PresentationValidationResult<string> ContentCheck(string text)
        {
            return text.Length<=PrivateMessage.MaxTextLength
                ? PresentationValidationResult<string>.Success(text)
                : PresentationValidationResult<string>.Error("[red]Sadržaj poruke ima previše znakova[/]");
        }        
    }

}