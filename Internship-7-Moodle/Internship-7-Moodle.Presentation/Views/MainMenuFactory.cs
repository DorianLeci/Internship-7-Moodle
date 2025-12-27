using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Views.Common;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views;

public static class MainMenuFactory
{
    public static BaseMainMenuManager Create(UserActions userActions, RoleEnum role, int userId)
    {
        return role switch
        {
            RoleEnum.Student => new StudentMainMenuManager(userActions, userId),
            RoleEnum.Professor => new ProfessorMainMenuManager(userActions, userId),
            RoleEnum.Admin => new AdminMainMenuManager(userActions, userId), 
            _=> throw new ArgumentException("Nepoznata uloga")
        };
        
    }
}