using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Views.Common;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class AdminMainMenuManager:BaseMainMenuManager
{
    public AdminMainMenuManager(UserActions userActions, int userId) : base(userActions, userId)
    {
    }

    public override Task RunAsync()
    {
        throw new NotImplementedException();
    }
}