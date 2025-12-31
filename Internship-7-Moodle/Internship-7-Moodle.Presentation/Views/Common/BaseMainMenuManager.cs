using Internship_7_Moodle.Presentation.Actions;


namespace Internship_7_Moodle.Presentation.Views.Common;

public abstract class BaseMainMenuManager
{
    public int Id { get; }

    public ChatFeature ChatFeature { get; set; }
    
    protected readonly UserActions UserActions;

    protected BaseMainMenuManager(int userId, ChatFeature chatFeature, UserActions userActions)
    {
        Id = userId;
        ChatFeature = chatFeature;
        UserActions = userActions;
    }

    public abstract Task RunAsync();
    
    
}
    