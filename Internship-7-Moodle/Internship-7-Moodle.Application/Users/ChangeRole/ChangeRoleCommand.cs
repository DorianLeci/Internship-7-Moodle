using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using MediatR;

namespace Internship_7_Moodle.Application.Users.ChangeRole;

public record ChangeRoleCommand(int UserId):IRequest<AppResult<UserResponse>>
{
    
}