using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.RegisterUser;
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

    public async Task RegisterUserAsync()
    {
        // var registerDto = new RegisterUserDto();
        // await _mediator.Send(RegisterUserCommand.FromDto())

    }
}