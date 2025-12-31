using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Chat;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Chats;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;

namespace Internship_7_Moodle.Application.Chat.SendMessage;

public class SendMessageCommandHandler:IRequestHandler<SendMessageCommand,AppResult<PrivateMessageResponse>>
{
    private readonly IChatUnitOfWork _chatUnitOfWork;
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly ChatDomainService _chatDomainService;

    public SendMessageCommandHandler(IChatUnitOfWork chatUnitOfWork, ChatDomainService chatDomainService, IUserUnitOfWork userUnitOfWork)
    {
        _chatUnitOfWork = chatUnitOfWork;
        _chatDomainService = chatDomainService;
        _userUnitOfWork = userUnitOfWork;
    }
    
    public async Task<AppResult<PrivateMessageResponse>> Handle(SendMessageCommand command, CancellationToken cancellationToken)
    {
        var result=new AppResult<PrivateMessageResponse>();
        
        var currentUser = await _userUnitOfWork.UserRepository.GetByIdAsync(command.CurrentUserId);
        var otherUser = await _userUnitOfWork.UserRepository.GetByIdAsync(command.OtherUserId);

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

        var chat = await _chatUnitOfWork.ChatRepository.GetChatAsync(userAId, userBId) 
                   ?? _chatDomainService.CreateChat(userAId, userBId);
        
        var message = new PrivateMessage
        {
            SenderId = currentUser.Id,
            ReceiverId = otherUser.Id,
            Text = command.Text,
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
            await _chatUnitOfWork.ChatRepository.InsertAsync(chat);
        
        await _chatUnitOfWork.MessageRepository.InsertAsync(message);
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