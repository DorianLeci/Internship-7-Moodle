using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.PromptFunctions;
using Internship_7_Moodle.Presentation.Helpers.PromptHelpers;
using Internship_7_Moodle.Presentation.Helpers.Reader;
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

        var title = isMyCourseSubmenu ? "[yellow] Moji kolegiji[/]" : "[yellow] Upravljanje kolegijima[/]";

        await MenuRunner.RunMenuAsync(myCourseMenu, title);

    }
    
    public async Task ShowCourseSubmenuAsync(CourseResponse course,bool isMyCourseSubmenu)
    {
        var courseSubmenu = isMyCourseSubmenu ?
            MenuBuilder.MenuBuilder.CreateCourseScreen(this, course.CourseId):
            MenuBuilder.MenuBuilder.CreateCourseManagementScreen(this, course.CourseId);

        var title = isMyCourseSubmenu ? "[yellow] Kolegij screen[/]" : "[yellow] Kolegij management screen[/]";
        
        await MenuRunner.RunMenuAsync(courseSubmenu,title);
    }

    public async Task ShowAllStudentsEnrolled(int courseId)
    {
        ConsoleHelper.MenuChoiceSuccess("[green]Uspješan odabir[/]");
        
        var studentsEnrolled=await _courseActions.GetAllStudentsEnrolledAsync(courseId);
        var studentsEnrolledList = studentsEnrolled.ToList();

        if (studentsEnrolledList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red]Niti jedan student nije upisan na kolegij.Izlazak...[/]");
            return;
        }
        
        Writer.Course.StudentsEnrolledWriter(studentsEnrolledList);
        
        ConsoleHelper.ScreenExit(1500);
    }
    
    public async Task ShowCourseNotificationsAsync(int courseId)
    {
        var notifications = await _courseActions.GetAllNotificationsAsync(courseId,RoleEnum.Professor);
        var notificationList = notifications.ToList();
        
        if (notificationList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red]Ne postoje dostupne obavijesti.Izlazak...[/]");
            return;
        }
        
        Writer.Course.NotificationWriter(notificationList);

        ConsoleHelper.ScreenExit(1500);
    }
    
    public async Task ShowCourseMaterialsAsync(int courseId)
    {
        
        var materials = await _courseActions.GetAllMaterialsAsync(courseId);
        var materialList = materials.ToList();
        
        if (materialList.Count == 0)
        {
            ConsoleHelper.SleepAndClear(2000,"[red]Ne postoje dostupni materijali.Izlazak...[/]");
            return;
        }
        
        Writer.Course.MaterialsWriter(materialList);

        ConsoleHelper.ScreenExit(1500); 
    }

    public async Task HandleCourseNotificationPublish(int courseId)
    {
        const string publishNotificationExit="[blue]Izlazak iz unosa obavijesti...[/]";
        const string title = "[yellow]Želiš li odustati od unosa obavijesti[/]";
            
        while (true)
        {
            var subjectResult = await FieldPrompt.PromptWithValidation(() => ChoiceMenu.ShowChoiceMenuAsync(title: title),
                    "Unesi naslov",subject=>PromptFunctions.Course.SubjectCheck(subject));
            
            if (subjectResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishNotificationExit);
                return;
            }
                
            var contentResult = await MultilineReader.ReadMultilineInput(() => ChoiceMenu.ShowChoiceMenuAsync(title: title),
                "Unesi sadržaj",content=>PromptFunctions.Course.ContentCheck(content));

            if (contentResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishNotificationExit);
                return;
            }
            
            var response=await _courseActions.PublishCourseNotificationAsync(subjectResult.Value, contentResult.Value,courseId);

            AnsiConsole.WriteLine();
            
            if (response.IsFailure)
            {
                Writer.Common.ErrorWriter(response,"[red]Unos obavijesti nesupješan[/]");
                
                var isPublishingRequested = await ChoiceMenu.ShowChoiceMenuAsync(("Pokušaj ponovno",true),("Odustani",false),"[yellow]Želiš li pokušati ponovno?[/]");
                if (isPublishingRequested) continue;
                
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishNotificationExit);
                return;
            }
            
            Writer.Course.NotificationPublishedWriter();
            ConsoleHelper.SleepAndClear(2000);
            return;



        }
    }
}