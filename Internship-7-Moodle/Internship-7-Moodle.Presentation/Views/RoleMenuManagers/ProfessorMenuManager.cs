using Internship_7_Moodle.Presentation.Actions;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class ProfessorMenuManager:BaseMenuManager
{
    public ProfessorMenuManager(UserActions userActions, int userId) : base(userActions, userId)
    {
    }

    public override Task RunAsync()
    {
        throw new NotImplementedException();
    }
}