using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Application.Users.DeleteUser;
using Internship_7_Moodle.Application.Users.GetAllCourses;
using Internship_7_Moodle.Application.Users.GetAllProfessorCourses;
using Internship_7_Moodle.Application.Users.GetAllUsers;
using Internship_7_Moodle.Application.Users.LoginUser;
using Internship_7_Moodle.Application.Users.RegisterUser;
using Internship_7_Moodle.Domain.Enumerations;
using MediatR;


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

    public async Task<IEnumerable<CourseResponse>> GetStudentCoursesAsync(int studentId)
    {
        var result = await _mediator.Send(new GetStudentCoursesRequest(studentId));

        if (result.Value == null)
            return [];
        
        var courses = result.Value.Entities;

        return courses;
        
    }

    public async Task<IEnumerable<CourseResponse>> GetAllProfessorCoursesAsync(int professorId)
    {
        var result = await _mediator.Send(new GetAllProfessorCoursesRequest(professorId));

        if (result.Value == null)
            return [];
        
        var courses = result.Value.Entities;

        return courses;
    }

    public async Task<AppResult<SuccessResponse>> DeleteUserAsync(int userId)
    {
        return await _mediator.Send(new DeleteUserCommand(userId));
    }

    public async Task<IEnumerable<UserResponse>> GetAllUsersAsync(int adminId,RoleEnum ? roleFilter=null)
    {
        var result = await _mediator.Send(new GetAllUsersToDeleteRequest(adminId,roleFilter));
        
        if (result.Value == null)
            return [];
        
        var allUsers = result.Value.Entities;

        return allUsers;
    }
    
}