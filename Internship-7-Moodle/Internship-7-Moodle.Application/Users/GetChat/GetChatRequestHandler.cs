using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetChat;

public class GetChatRequestHandler:IRequestHandler<GetChatRequest,AppResult<ChatResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly ChatDomainService _chatDomainService;

    public GetChatRequestHandler(IUserUnitOfWork userUnitOfWork, ChatDomainService chatDomainService)
    {
        _userUnitOfWork = userUnitOfWork;
        _chatDomainService = chatDomainService;
    }
    public async Task<AppResult<ChatResponse>> Handle(GetChatRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<ChatResponse>();
        
        var currentUser = await _userUnitOfWork.UserRepository.GetByIdAsync(request.CurrentUserId);
        var otherUser = await _userUnitOfWork.UserRepository.GetByIdAsync(request.OtherUserId);

        if (currentUser == null || otherUser == null)
        {
            var validationResult = new ValidationResult();
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(User),"Jedan od korisnika"));
            result.SetValidationResult(validationResult);
            return result;
        }

        var chatValidation = _chatDomainService.ValidateUsersForChat(currentUser, otherUser);
        if (chatValidation.HasErrors)
        {
            result.SetValidationResult(chatValidation);
            return result;
        }
        
        var (userAId, userBId) = _chatDomainService.GetOrderedUserIds(currentUser, otherUser);

        var chat = await _userUnitOfWork.ChatRepository.GetChatAsync(userAId, userBId);
        
        var chatResponse = new ChatResponse
        {
            ChatId = chat?.Id ?? 0,
            CurrentUserId = currentUser.Id,
            OtherUserId = otherUser.Id,
            CurrentUserName = currentUser.FirstName+" "+currentUser.LastName,
            OtherUserName = otherUser.FirstName + " " + otherUser.LastName,
            
            Messages = (chat!=null) ? chat.PrivateMessages
                .OrderBy(pm=>pm.CreatedAt)
                .Select(pm=>new PrivateMessageResponse
                {
                    MessageId = pm.Id,
                    SenderId = pm.SenderId,
                    ReceiverId = pm.ReceiverId,
                    SenderName = pm.Sender.FirstName + " " + pm.Sender.LastName,
                    Content = pm.Text,
                    SentAt = pm.CreatedAt,
                    IsRead = pm.IsRead
                }).ToList(): new List<PrivateMessageResponse>()
            
        };
        
        result.SetResult(chatResponse);
        return result;

    }
}