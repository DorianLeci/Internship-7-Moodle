using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetRegisteredUsersByRole;

public record GetRegisteredUsersByRoleRequest(PeriodEnum Period):IRequest<AppResult<GetAllResponse<CountByRoleResponse>>>
{
    
}