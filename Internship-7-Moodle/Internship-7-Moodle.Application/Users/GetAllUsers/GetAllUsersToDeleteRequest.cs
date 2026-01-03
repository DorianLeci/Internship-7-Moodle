using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Enumerations;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllUsers;

public record GetAllUsersByRoleRequest(RoleEnum? RoleFilter=null):IRequest<AppResult<GetAllResponse<UserResponse>>>
{
    
}