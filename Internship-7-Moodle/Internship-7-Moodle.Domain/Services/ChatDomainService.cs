using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Services;

public class ChatDomainService
{
    public ValidationResult ValidateUsersForChat(User currentUser, User otherUser)
    {
        var validationResult = new ValidationResult();
        if (currentUser.Id == otherUser.Id)
        {
            validationResult.Add(EntityValidation.ChatValidation.ItemMustBeDifferent(nameof(User),
                "Korisnici ne smije imati chat sam sa sobom"));
            
        }
        return validationResult;
    }
    
    public Chat CreateChat(int userAId,int userBId)
    {
        return new Chat
        {
            UserAId = userAId,
            UserBId = userBId
        };
    }

    public (int UserAId, int UserBId) GetOrderedUserIds(User user1, User user2)
    {
        return (
            Math.Min(user1.Id, user2.Id),
            Math.Max(user1.Id, user2.Id)
        );
    }
}