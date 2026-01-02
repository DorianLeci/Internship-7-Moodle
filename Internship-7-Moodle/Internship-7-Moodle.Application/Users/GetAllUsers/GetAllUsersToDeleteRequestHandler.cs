using System.Linq.Expressions;
using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllUsers;

public class GetAllUsersToDeleteRequestHandler:IRequestHandler<GetAllUsersToDeleteRequest,AppResult<GetAllResponse<UserResponse>>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;

    public GetAllUsersToDeleteRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<UserResponse>>> Handle(GetAllUsersToDeleteRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<UserResponse>>();

        var predicate = request.RoleFilter.HasValue
            ? (Expression<Func<User, bool>>)(u => u.Role.RoleName == request.RoleFilter)
            : (Expression<Func<User, bool>>)(u => u.Id != request.AdminId);
        
        var users = await _userUnitOfWork.UserRepository
            .GetAllAsync
            (predicate,u=>u.OrderByDescending(usr=>usr.CreatedAt).ThenBy(usr=>usr.FirstName).ThenBy(usr=>usr.LastName), 
                u => u.Role);

        var userResponses = users
            .Select(u => new UserResponse
            {
                Id = u.Id,
                FirstName = u.FirstName!,
                LastName = u.LastName!,
                RoleName = u.Role.RoleName,
            });
        
        result.SetResult(new GetAllResponse<UserResponse>(userResponses));
        
        return result;
    }
}