using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Chats;
using MediatR;

namespace Internship_7_Moodle.Application.Chat.UpdateUnreadMessage;

public class UpdateUnreadMessagesRequestHandler:IRequestHandler<UpdateUnreadMessagesRequest,AppResult<EmptyResult>>
{
    private readonly IChatUnitOfWork _chatUnitOfWork;

    public UpdateUnreadMessagesRequestHandler(IChatUnitOfWork chatUnitOfWork)
    {
        _chatUnitOfWork = chatUnitOfWork;
    }

    
    public async Task<AppResult<EmptyResult>> Handle(UpdateUnreadMessagesRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<EmptyResult>();
        if (request.MessageIdList != null && request.MessageIdList.Any())
        {
            var messages = await _chatUnitOfWork.MessageRepository.GetPrivateMessagesAsync(request.MessageIdList);
            
            foreach (var msg in messages)
            {
                msg.IsRead = true;
            }

            await _chatUnitOfWork.SaveAsync();
        }


        result.SetResult(new EmptyResult());
        return result;
    }
}