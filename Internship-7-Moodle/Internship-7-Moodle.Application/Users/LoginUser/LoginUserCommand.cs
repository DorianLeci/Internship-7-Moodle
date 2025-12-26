using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.Response;
using MediatR;

namespace Internship_7_Moodle.Application.Users.LoginUser;

public record LoginUserCommand(string  Email, string Password):IRequest<AppResult<UserLoginResponse>>
{
    public static LoginUserCommand FromDto(LoginUserDto dto)
    {
        return new LoginUserCommand(dto.Email, dto.Password);
    }
}