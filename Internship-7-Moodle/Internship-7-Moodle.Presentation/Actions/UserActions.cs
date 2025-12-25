using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.RegisterUser;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Presentation.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
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
}