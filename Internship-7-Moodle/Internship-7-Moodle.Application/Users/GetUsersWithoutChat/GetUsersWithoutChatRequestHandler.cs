using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetUsersWithoutChat;

public class GetUsersWithoutChatRequestHandler:IRequestHandler<GetUsersWithoutChatRequest,AppResult<GetAllResponse<UserResponse>>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    
    public GetUsersWithoutChatRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<UserResponse>>> Handle(GetUsersWithoutChatRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<UserResponse>>();

        var users = await _userUnitOfWork.MessageRepository.GetUsersWithoutChatAsync(request.UserId,request.RoleFilter);

        var userResponses = users.Select(u=>new UserResponse
            {
                Id=u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                RoleName = u.Role.RoleName
            }
            );
        
        result.SetResult(new GetAllResponse<UserResponse>(userResponses));
        return result;
    }
}
