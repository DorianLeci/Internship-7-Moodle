using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetRegisteredUsersByRole;

public class GetRegisteredUsersByRoleHandler : IRequestHandler<GetRegisteredUsersByRoleRequest, AppResult<GetAllResponse<CountByRoleResponse>>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;

    public GetRegisteredUsersByRoleHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }

    public async Task<AppResult<GetAllResponse<CountByRoleResponse>>> Handle(GetRegisteredUsersByRoleRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<GetAllResponse<CountByRoleResponse>>();
        
        var roleCounts = await _userUnitOfWork.UserRepository.GetUserCountGroupedByRole(request.Period);

        var responses = roleCounts.Select(x => new CountByRoleResponse
        {
            RoleName = x.Role,
            Count = x.Count
        });
        
        result.SetResult(new GetAllResponse<CountByRoleResponse>(responses));

        return result;
    }
}