using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetChat;

public class GetOrCreateChatRequestHandler:IRequestHandler<GetOrCreateChatRequest,AppResult<ChatResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;

    public GetOrCreateChatRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    public async Task<AppResult<ChatResponse>> Handle(GetOrCreateChatRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<ChatResponse>();
        var validationResult = new ValidationResult();
        
        var currentUser = await _userUnitOfWork.UserRepository.GetByIdAsync(request.CurrentUserId);
        var otherUser = await _userUnitOfWork.UserRepository.GetByIdAsync(request.OtherUserId);

        if (currentUser == null || otherUser == null)
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(User),"Jedan od korisnika"));
            result.SetValidationResult(validationResult);
            return result;
        }

        if (currentUser.Id == otherUser.Id)
        {
            validationResult.Add(EntityValidation.ChatValidation.ItemMustBeDifferent(nameof(User),
                "Korisnici ne smije imati chat sam sa sobom"));
            result.SetValidationResult(validationResult);
            return result;
        }
        
        var userAId = Math.Min(currentUser.Id, otherUser.Id);
        var userBId = Math.Max(currentUser.Id, otherUser.Id);
        
        var chat=await _userUnitOfWork.ChatRepository.GetChatAsync(userAId, userBId) ?? new Chat
        {
            UserAId = userAId,
            UserBId = userBId,
        };
        
        bool isChatNew = chat.Id == 0;

        var chatResponse = new ChatResponse
        {
            ChatId = chat.Id,
            CurrentUserId = currentUser.Id,
            OtherUserId = otherUser.Id,
            CurrentUserName = currentUser.FirstName+" "+currentUser.LastName,
            OtherUserName = otherUser.FirstName + " " + otherUser.LastName,
            
            Messages = chat.PrivateMessages
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
            }).ToList()
            
        };

        if (isChatNew)
        {
            await _userUnitOfWork.ChatRepository.InsertAsync(chat);
            await _userUnitOfWork.SaveAsync();            
        }

        
        result.SetResult(chatResponse);
        return result;

    }
}