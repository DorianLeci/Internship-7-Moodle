using Internship_7_Moodle.Presentation.Actions;

namespace Internship_7_Moodle.Presentation.Views.Common;

public abstract class BaseMainMenuManager
{
    protected readonly UserActions UserActions;
    protected readonly int UserId;
    
    public int Id => UserId;

    protected BaseMainMenuManager(UserActions userActions,int userId)
    {
        UserActions = userActions;
        UserId = userId;
    }

    public abstract Task RunAsync();

    public async Task ShowPrivateChatMenuAsync()
    {
        var messages=
    }

}