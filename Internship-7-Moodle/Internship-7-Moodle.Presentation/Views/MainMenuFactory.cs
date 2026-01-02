using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Views.Common;
using Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

namespace Internship_7_Moodle.Presentation.Views;

public static class MainMenuFactory
{
    public static BaseMainMenuManager Create(MenuDependencies.MenuDependencies menuDependencies, RoleEnum role, int userId)
    {
        var chatFeature = new ChatFeature(menuDependencies.ChatActions, userId);
        
        return role switch
        {
            RoleEnum.Student => new StudentMainMenuManager(
                userId, 
                chatFeature, 
                menuDependencies.UserActions, 
                menuDependencies.CourseActions
            ),

            RoleEnum.Professor => new ProfessorMainMenuManager(
                userId, 
                chatFeature, 
                menuDependencies.UserActions, 
                menuDependencies.CourseActions
            ),

            RoleEnum.Admin => new AdminMainMenuManager(
                userId, 
                chatFeature, 
                menuDependencies.UserActions
            ),

            _ => throw new ArgumentException("Nepoznata uloga")
        };
        
    }
}