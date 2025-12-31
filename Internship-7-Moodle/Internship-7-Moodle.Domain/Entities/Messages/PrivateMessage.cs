using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Entities.Messages;

public class PrivateMessage:BaseEntity
{
    public const int MaxTextLength = 1000;
    public string? Text { get; set; }
    public bool IsRead { get; set; }
    
    public int SenderId { get; set; }
    public User Sender { get; set; } = null!;

    public int ReceiverId { get; set; }
    public User Receiver { get; set; } = null!;
    
    public int ChatId{get;set;}

    public Chat Chat { get; set; } = null!;
    
    public Result<int> Create()
    {
        var result = Validate();
        return result.HasErrors ? Result<int>.Failure(result) : Result<int>.Success(Id);
    }
    
    private ValidationResult Validate()
    {
        var validationResult = new ValidationResult();
        
        CheckTextLength(validationResult);
        return validationResult;
    }

    private void CheckTextLength(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(Text))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(PrivateMessage),"Sadržaj poruke"));
        if(Text?.Length>MaxTextLength)
            validationResult.Add(EntityValidation.MessageValidation.MaxTextLength);      
    }

}