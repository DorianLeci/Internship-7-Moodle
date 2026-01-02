using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Response.User;
using MediatR;

namespace Internship_7_Moodle.Application.Users.ChangeEmail;

public record ChangeEmailCommand(int UserId,string NewEmail):IRequest<AppResult<ChangeEmailResponse>>
{
    public static ChangeEmailCommand FromDto(ChangeEmailDto dto)
    {
        return new ChangeEmailCommand(dto.UserId,dto.NewEmail);
    }
}