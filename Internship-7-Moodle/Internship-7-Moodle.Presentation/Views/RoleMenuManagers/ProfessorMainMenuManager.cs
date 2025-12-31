using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.Writers;
using Internship_7_Moodle.Presentation.Views.Common;
using Spectre.Console;

namespace Internship_7_Moodle.Presentation.Views.RoleMenuManagers;

public class ProfessorMainMenuManager:BaseMainMenuManager
{
    private readonly CourseActions _courseActions;
    public ProfessorMainMenuManager(int userId,ChatFeature chatFeature,UserActions userActions, CourseActions courseActions) : base(userId,chatFeature,userActions)
    {
        _courseActions = courseActions;
    }

    public override async Task RunAsync()
    { 
        var mainMenu = MenuBuilder.MenuBuilder.CreateProfessorMenu(this);

        await MenuRunner.RunMenuAsync(mainMenu,"[yellow] Glavni izbornik[/]",exitChoice:"Odjava");
    }

    public async Task ShowCourseMenuAsync(int professorId,bool isMyCourseSubmenu)
    {
        
        var professorCourses=await UserActions.GetAllProfessorCoursesAsync(professorId);
        var professorCoursesList = professorCourses.ToList();

        if (professorCoursesList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red]Ne postoje dostupni kolegiji.Izlazak...[/]");
            return;
        }

        var myCourseMenu=MenuBuilder.MenuBuilder.CreateCourseMenu(this,professorCoursesList,isMyCourseSubmenu);

        var title = isMyCourseSubmenu ? "[yellow] Moji kolegiji[/]" : "[yellow] Upravljanje kolegijima";

        await MenuRunner.RunMenuAsync(myCourseMenu, title);

    }
    
    public async Task ShowCourseSubmenuAsync(CourseResponse course,bool isMyCourseSubmenu)
    {
        var courseSubmenu = MenuBuilder.MenuBuilder.CreateCourseScreen(this, course.CourseId);
        
        await MenuRunner.RunMenuAsync(courseSubmenu,"[yellow] Kolegij screen[/]");
    }

    public async Task ShowAllStudentsEnrolled(int courseId)
    {
        ConsoleHelper.MenuChoiceSuccess("[green]Uspješan odabir[/]");
        
        var studentsEnrolled=await _courseActions.GetAllStudentsEnrolledAsync(courseId);
        var studentsEnrolledList = studentsEnrolled.ToList();

        if (studentsEnrolledList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(1000,"[red]Niti jedan student nije upisan na kolegij.Izlazak...[/]");
            return;
        }
        
        Writer.Course.StudentsEnrolledWriter(studentsEnrolledList);
        
        ConsoleHelper.ScreenExit(1500);
        
    }
}