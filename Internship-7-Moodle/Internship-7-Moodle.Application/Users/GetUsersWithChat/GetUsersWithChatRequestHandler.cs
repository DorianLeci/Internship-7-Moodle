using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetUsersWithChat;

public class GetUsersWithChatRequestHandler:IRequestHandler<GetUsersWithChatRequest, AppResult<GetAllResponse<UserResponse>>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    
    public GetUsersWithChatRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<UserResponse>>> Handle(GetUsersWithChatRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<UserResponse>>();

        var users = await _userUnitOfWork.MessageRepository.GetUsersWithChatAsync(request.UserId,request.RoleFilter);

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