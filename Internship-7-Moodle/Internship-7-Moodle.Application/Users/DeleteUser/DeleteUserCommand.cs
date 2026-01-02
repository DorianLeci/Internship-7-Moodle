using Internship_7_Moodle.Application.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Users.DeleteUser;

public record DeleteUserCommand(int UserId):IRequest<AppResult<SuccessResponse>>
{
}