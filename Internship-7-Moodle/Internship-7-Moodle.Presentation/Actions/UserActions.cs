using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Courses.GetAllMaterials;
using Internship_7_Moodle.Application.Courses.GetAllNotifications;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.GetAllCourses;
using Internship_7_Moodle.Application.Users.GetChat;
using Internship_7_Moodle.Application.Users.GetUsersWithoutChat;
using Internship_7_Moodle.Application.Users.LoginUser;
using Internship_7_Moodle.Application.Users.RegisterUser;
using Internship_7_Moodle.Application.Users.Response;
using Internship_7_Moodle.Application.Users.Response.Course;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Application.Users.SendMessage;
using Internship_7_Moodle.Domain.Enumerations;
using MediatR;
using Spectre.Console;


namespace Internship_7_Moodle.Presentation.Actions;

public class UserActions
{
    private readonly IMediator _mediator;

    public UserActions(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<AppResult<SuccessPostResponse>> RegisterUserAsync(string firstName,string lastName,DateOnly birthDate,string email,GenderEnum? gender,string password, RoleEnum roleName)
    {
        var registerDto = new RegisterUserDto(firstName, lastName, birthDate, email, gender, password, roleName);
        
        return await _mediator.Send(RegisterUserCommand.FromDto(registerDto));
        
    }

    public async Task<AppResult<UserLoginResponse>> LoginUserAsync(string email,string password)
    {
        var loginDto = new LoginUserDto(email, password);
        
        return await _mediator.Send(LoginUserCommand.FromDto(loginDto));
        
    }

    public async Task<IEnumerable<StudentCourseResponse>> GetStudentCoursesAsync(int studentId)
    {
        var result = await _mediator.Send(new GetStudentCoursesRequest(studentId));

        if (result.Value == null)
            return [];
        
        var courses = result.Value.Entities;

        return courses;
        
    }

    public async Task<IEnumerable<NotificationResponse>> GetAllNotificationsAsync(int courseId)
    {
        
        var result = await _mediator.Send(new GetAllNotificationsRequest(courseId));

        if (result.Value == null)
            return [];

        var courses = result.Value.Entities;

        return courses;
    }

    public async Task<IEnumerable<MaterialResponse>> GetAllMaterialsAsync(int courseId)
    {
        var result = await _mediator.Send(new GetAllMaterialsRequest(courseId));

        if (result.Value == null)
            return [];

        var materials = result.Value.Entities;

        return materials;        
    }

    public async Task<IEnumerable<UserResponse>> GetAllUsersWithoutChatAsync(int userId,RoleEnum? roleFilter=null)
    {
        var dto=new GetUserChatDto(userId,roleFilter);
        var result = await _mediator.Send(GetUsersWithoutChatRequest.FromDto(dto));

        if (result.Value == null)
            return [];
        
        var  users = result.Value.Entities;
        
        return users;

    }

    public async Task<AppResult<ChatResponse>> GetOrCreateChatAsync(int currentUserId, int otherUserId)
    {
        return await _mediator.Send(new GetChatRequest(currentUserId, otherUserId));
    }

    public async Task<AppResult<PrivateMessageResponse>> SendPrivateMessageAsync(int currentUserId, int otherUserId,string text)
    {
        var dto=new SendMessageDto(currentUserId, otherUserId, text);
        
        return await _mediator.Send(SendMessageCommand.FromDto(dto));
    }
    
}