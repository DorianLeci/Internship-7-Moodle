using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Chat;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Chats;
using MediatR;

namespace Internship_7_Moodle.Application.Chat.GetTopUsersBySentMsg;

public class GetTopUsersRequestHandler:IRequestHandler<GetTopUsersRequest,AppResult<GetAllResponse<TopUsersByMsgResponse>>>
{
    private readonly IChatUnitOfWork _chatUnitOfWork;

    public GetTopUsersRequestHandler(IChatUnitOfWork chatUnitOfWork)
    {
        _chatUnitOfWork = chatUnitOfWork;
    }
    
    public async Task<AppResult<GetAllResponse<TopUsersByMsgResponse>>> Handle(GetTopUsersRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<TopUsersByMsgResponse>>();

        var topUsers = await _chatUnitOfWork.ChatRepository.GetTopUsersByMsgSent(request.Period);

        var topUserRespones = topUsers.Select(u => new TopUsersByMsgResponse
        {
            UserId = u.UserId,
            FullName = u.FullName,
            MsgSentCount = u.MsgCount
        });
        
        result.SetResult(new GetAllResponse<TopUsersByMsgResponse>(topUserRespones));
        
        return result;
    }
}