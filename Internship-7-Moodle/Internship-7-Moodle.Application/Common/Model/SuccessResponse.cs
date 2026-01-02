namespace Internship_7_Moodle.Application.Common.Model;

public class SuccessResponse
{
    public string Message { get; init; }

    public SuccessResponse(string message)
    {
        Message = message;
    }
}