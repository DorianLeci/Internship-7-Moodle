using Internship_7_Moodle.Application.Response.Chat;
using Internship_7_Moodle.Presentation.Actions;

namespace Internship_7_Moodle.Presentation.Helpers.UiState;

public class ChatUiState
{
    public ChatResponse Chat { get; set; }
    
    public string ?Error { get; set; }

    public bool Exit { get; set; } = false;
    
    public ChatActions ChatActions { get; set; }
    
    public string InputBuffer { get; set; } = "";
    
    public int ScrollOffset { get; set; } = 0;
    public int MaxVisibleMessages { get; set; } = 10;
    
    
    public ChatUiState(ChatResponse chat, ChatActions chatActions)
    {
        Chat = chat;
        ChatActions = chatActions;
    }
}