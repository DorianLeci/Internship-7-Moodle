using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.LoginUser;
using Internship_7_Moodle.Application.Users.RegisterUser;
using Internship_7_Moodle.Application.Users.Response;
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
}