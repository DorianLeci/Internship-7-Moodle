using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Views.Common;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class AdminMainMenuManager:BaseMainMenuManager
{
    private readonly CourseActions _courseActions;
    public AdminMainMenuManager(int userId,ChatFeature chatFeature,UserActions userActions, CourseActions courseActions) : base(userId,chatFeature,userActions)
    {
        _courseActions = courseActions;
    }
    
    public override Task RunAsync()
    {
        throw new NotImplementedException();
    }
}