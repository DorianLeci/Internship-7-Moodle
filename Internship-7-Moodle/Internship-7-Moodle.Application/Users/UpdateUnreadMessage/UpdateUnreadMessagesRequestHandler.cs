using FluentValidation.Results;
using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.UpdateUnreadMessage;

public class UpdateUnreadMessagesRequestHandler:IRequestHandler<UpdateUnreadMessagesRequest,AppResult<EmptyResult>>
{
    IUserUnitOfWork _userUnitOfWork;

    public UpdateUnreadMessagesRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    public async Task<AppResult<EmptyResult>> Handle(UpdateUnreadMessagesRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<EmptyResult>();
        if (request.MessageIdList != null && request.MessageIdList.Any())
        {
            var messages = await _userUnitOfWork.MessageRepository.GetPrivateMessagesAsync(request.MessageIdList);
            
            foreach (var msg in messages)
            {
                msg.IsRead = true;
            }

            await _userUnitOfWork.SaveAsync();
        }


        result.SetResult(new EmptyResult());
        return result;
    }
}