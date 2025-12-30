using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Presentation.Actions;

namespace Internship_7_Moodle.Presentation.Helpers.UiState;

public class ChatUiState
{
    public ChatResponse Chat { get; set; }
    
    public string ?Error { get; set; }

    public bool Exit { get; set; } = false;
    
    public UserActions UserActions { get; set; }
    
    public string InputBuffer { get; set; } = "";
    
    public int ScrollOffset { get; set; } = 0; 
    public int MaxVisibleMessages { get; set; } = 5;
    public ChatUiState(ChatResponse chat, UserActions userActions)
    {
        Chat = chat;
        UserActions = userActions;
    }
}