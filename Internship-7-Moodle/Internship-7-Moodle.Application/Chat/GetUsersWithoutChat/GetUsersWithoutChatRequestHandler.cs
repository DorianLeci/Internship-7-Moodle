using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Chats;
using MediatR;

namespace Internship_7_Moodle.Application.Chat.GetUsersWithoutChat;

public class GetUsersWithoutChatRequestHandler:IRequestHandler<GetUsersWithoutChatRequest,AppResult<GetAllResponse<UserResponse>>>
{
    private readonly IChatUnitOfWork _chatUnitOfWork;

    public GetUsersWithoutChatRequestHandler(IChatUnitOfWork chatUnitOfWork)
    {
        _chatUnitOfWork = chatUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<UserResponse>>> Handle(GetUsersWithoutChatRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<UserResponse>>();

        var users = await _chatUnitOfWork.ChatRepository.GetUsersWithoutChatAsync(request.UserId,request.RoleFilter);

        var userResponses = users.Select(u=>new UserResponse
            {
                Id=u.Id,
                FirstName = u.FirstName!,
                LastName = u.LastName!,
                RoleName = u.Role.RoleName
            }
            );
        
        result.SetResult(new GetAllResponse<UserResponse>(userResponses));
        return result;
    }
}
