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
    
    public override async Task RunAsync()
    {
        var mainMenu = MenuBuilder.MenuBuilder.CreateAdminMenu(this);

        await MenuRunner.RunMenuAsync(mainMenu,"[yellow] Glavni izbornik[/]",exitChoice:"Odjava");
    }

    public async Task ShowDeleteUserMenuAsync()
    {
                
        // var professorCourses=await UserActions.GetAllProfessorCoursesAsync(professorId);
        // var professorCoursesList = professorCourses.ToList();
        //
        // if (professorCoursesList.Count == 0)
        // {
        //     ConsoleHelper.SleepAndClear(2000,"[red bold]Ne postoje dostupni kolegiji.Izlazak...[/]");
        //     return;
        // }
        //
        // var myCourseMenu=MenuBuilder.MenuBuilder.CreateCourseMenu(this,professorCoursesList,isMyCourseSubmenu);
        //
        // var title = isMyCourseSubmenu ? "[yellow] Moji kolegiji[/]" : "[yellow] Upravljanje kolegijima[/]";
        //
        // await MenuRunner.RunMenuAsync(myCourseMenu, title);
    }
}