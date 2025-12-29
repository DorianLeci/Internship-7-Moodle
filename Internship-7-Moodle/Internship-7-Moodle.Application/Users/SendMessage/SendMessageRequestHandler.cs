using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;

namespace Internship_7_Moodle.Application.Users.SendMessage;

public class SendMessageRequestHandler:IRequestHandler<SendMessageRequest,AppResult<PrivateMessageResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly ChatDomainService _chatDomainService;

    public SendMessageRequestHandler(IUserUnitOfWork userUnitOfWork, ChatDomainService chatDomainService)
    {
        _userUnitOfWork = userUnitOfWork;
        _chatDomainService = chatDomainService;
    }
    
    public async Task<AppResult<PrivateMessageResponse>> Handle(SendMessageRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<PrivateMessageResponse>();
        
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

        var chat = await _userUnitOfWork.ChatRepository.GetChatAsync(userAId, userBId) 
                   ?? _chatDomainService.CreateChat(userAId, userBId);
        
        var message = new PrivateMessage
        {
            SenderId = currentUser.Id,
            ReceiverId = otherUser.Id,
            Text = request.Text,
            IsRead = false
        };
        
        var domainResult = message.Create();

        if (domainResult.IsFailure)
        {
            result.SetValidationResult(domainResult.ValidationResult!);
            return result;
        }
        
        chat.PrivateMessages.Add(message);
        
        if(chat.Id==0)
            await _userUnitOfWork.ChatRepository.InsertAsync(chat);
        
        await _userUnitOfWork.MessageRepository.InsertAsync(message);
        await _userUnitOfWork.SaveAsync();
        
        result.SetResult(new PrivateMessageResponse
            {
                MessageId = message.Id,
                SenderId = currentUser.Id,
                ReceiverId = otherUser.Id,
                SenderName =  currentUser.FirstName + " " + currentUser.LastName,
                Content =  message.Text,
                SentAt = message.CreatedAt,
                IsRead = message.IsRead,
                
            });
        return result;
    }
}