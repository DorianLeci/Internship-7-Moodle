using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.Helpers.ConsoleHelpers;
using Internship_7_Moodle.Presentation.Helpers.Format;
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
                    "Unesi naslov",PromptFunctions.Course.SubjectCheck);
            
            if (subjectResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishNotificationExit);
                return;
            }
                
            var contentResult = await MultilineReader.ReadMultilineInput(() => ChoiceMenu.ShowChoiceMenuAsync(title: title),
                "Unesi sadržaj",PromptFunctions.Course.ContentCheck);

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


    public async Task HandleCourseMaterialPublish(int courseId)
    {
        const string publishMaterialExit="[blue]Izlazak iz unosa materijala...[/]";
        const string title = "[yellow]Želiš li odustati od unosa materijala[/]";

        while (true)
        {
            var titleResult=await FieldPrompt.PromptWithValidation(() => ChoiceMenu.ShowChoiceMenuAsync(title: title),
                "Unesi naslov",PromptFunctions.Course.TitleCheck);

            if (titleResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishMaterialExit);
                return;                
            }
            
            var authorNameResult=await FieldPrompt.PromptWithValidation(() => ChoiceMenu.ShowChoiceMenuAsync(title: title),
                "Unesi ime i prezime autora",PromptFunctions.Course.AuthorNameCheck);
            
            if (authorNameResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishMaterialExit);
                return;                
            }
            
            var publishedDateResult=await FieldPrompt.PromptWithValidation(() => ChoiceMenu.ShowChoiceMenuAsync(title: title),
                "Unesi datum izdavanja(može biti prazno)",PromptFunctions.Course.PublishedDateCheck,allowEmpty:true);
            
            if (publishedDateResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishMaterialExit);
                return;                
            }
            
            var urlResult=await FieldPrompt.PromptWithValidation(() => ChoiceMenu.ShowChoiceMenuAsync(title: title),
                "Unesi url",PromptFunctions.Course.UrlCheck);
            
            if (urlResult.IsCancelled)
            {
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishMaterialExit);
                return;                
            }
            
            var response=await _courseActions.PublishCourseMaterialAsync
                (titleResult.Value,authorNameResult.Value,publishedDateResult.Value,urlResult.Value,courseId);

            AnsiConsole.WriteLine();
            
            if (response.IsFailure)
            {
                Writer.Common.ErrorWriter(response,"[red]Unos materijala nesupješan[/]");
                
                var isPublishingRequested = await ChoiceMenu.ShowChoiceMenuAsync(("Pokušaj ponovno",true),("Odustani",false),"[yellow]Želiš li pokušati ponovno?[/]");
                if (isPublishingRequested) continue;
                
                AnsiConsole.Clear();
                ConsoleHelper.SleepAndClear(2000,publishMaterialExit);
                return;
            }
            
            Writer.Course.MaterialPublishedWriter();
            ConsoleHelper.SleepAndClear(2000);
            return;
        }
    }

    public async Task ShowStudentsToAdd(int courseId)
    {
        var exitRequested = false;

        while (!exitRequested)
        {
            var students=await _courseActions.GetAllStudentsNotEnrolledAsync(courseId);
            
            var studentList=students.ToList();
            
            if (studentList.Count == 0)
            {
                ConsoleHelper.SleepAndClear(1500,"[red]Nema dostupnih korisnika.Izlazak...[/]");
                return;
            }

            var studentsToAddMenu = MenuBuilder.MenuBuilder.CreateStudentsToAddMenu(this, studentList, courseId);
            
            var prompt = new SelectionPrompt<string>()
                .Title(" [yellow]Dodaj studenta na kolegij[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Stisni strelicu prema dolje da vidiš više)[/]")
                .EnableSearch()
                .SearchPlaceholderText("Upiši ime studenta da pretražuješ")
                .AddChoices(studentsToAddMenu.Keys);

            prompt.SearchHighlightStyle = new Style().Background(ConsoleColor.DarkBlue);

            var choice = AnsiConsole.Prompt(prompt);
            
            exitRequested = await studentsToAddMenu[choice]();
        }
    }
    
    public async Task HandleStudentAddingToCourse(int courseId,int studentId)
    {
        var choice = await ChoiceMenu.ShowChoiceMenuAsync(("Da", true), ("Ne", false),
            "[yellow]Želiš li dodati studenta na kolegij[/]");

        if (!choice)
        {
            AnsiConsole.Clear();
            ConsoleHelper.SleepAndClear(2000,"[blue]Odustao si od dodavanja studenta na kolegij.Izlazak...[/]");
            return;            
        }

        var response=await _courseActions.AddStudentToCourseAsync(courseId, studentId);

        AnsiConsole.Clear();
        Writer.Course.StudentAddedWriter(response);
        
        ConsoleHelper.SleepAndClear(2000);
        
        
    }
}