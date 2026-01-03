namespace Internship_7_Moodle.Application.Response.Chat;

public class TopUsersByMsgResponse
{
    public int UserId { get; init; }

    public string FullName { get; init; } = null!;
    
    public int MsgSentCount {get; init;}
}