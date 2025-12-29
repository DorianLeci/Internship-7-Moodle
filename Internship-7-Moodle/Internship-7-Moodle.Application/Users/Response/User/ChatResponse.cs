namespace Internship_7_Moodle.Application.Users.Response.User;

public class ChatResponse
{
    public int ChatId { get; set; }   
    
    public int CurrentUserId { get; set; }    
    
    public int OtherUserId { get; set; }    
    
    public string CurrentUserName { get; set; }    
    
    public string OtherUserName { get; set; }   
    
    public List<PrivateMessageResponse> Messages { get; set; } = new();  
    
}