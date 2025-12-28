using System.Text.RegularExpressions;
using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Domain.Entities.Users;

public class User:BaseEntity
{
    public const int MaxFirstNameLength = 30;
    public const int MaxLastNameLength = 30;
    public const int MaxEmailLength = 50;
        
    public string FirstName{ get; set; }
    
    public string LastName{ get; set; }
    
    public DateOnly BirthDate{ get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public GenderEnum? Gender { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public ICollection<CourseUser> CourseEnrollments { get; set; }=new List<CourseUser>();
    
    public ICollection<PrivateMessage> SentMessages { get; set; }=new  List<PrivateMessage>();
    
    public ICollection<PrivateMessage> ReceivedMessages { get; set; }=new List<PrivateMessage>();
    
    public ICollection<Chat> ChatsAsUserA { get; set; } = new List<Chat>();
    public ICollection<Chat> ChatsAsUserB { get; set; } = new List<Chat>();

    public Result<int> Create()
    {
        var result = Validate();
        if (result.HasErrors)
            return Result<int>.Failure(result);
        
        return Result<int>.Success(Id);
    }
    
    private ValidationResult Validate()
    {
        var validationResult = new ValidationResult();
        
        CheckFirstName(validationResult);
        
        CheckLastName(validationResult);
        
        CheckEmail(validationResult);
        
        CheckBirthDate(validationResult);


        
        return validationResult;
    }

    private void CheckFirstName(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(FirstName))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Ime korisnika"));
        if(FirstName?.Length>MaxFirstNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxFirstNameLength);        
    }
    
    private void CheckLastName(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(LastName))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Prezime korisnika"));
        if(LastName?.Length>MaxLastNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxLastNameLength);        
    }

    private void CheckEmail(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(Email))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Email korisnika"));
        
        if(!CheckEmailFormat(Email))
            validationResult.Add(EntityValidation.UserValidation.EmailFormat);
        
        if(Email.Length>MaxEmailLength)
            validationResult.Add(EntityValidation.UserValidation.EmailLength);
    }

    private bool CheckEmailFormat(string email)
    {
        var regex = new Regex(@"^[^@]{1,}@[^@]{2,}\.[^@]{3,}$");
        return regex.IsMatch(email);
    }

    private void CheckBirthDate(ValidationResult validationResult)
    {
        if(string.IsNullOrWhiteSpace(Email))
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Datum rođenja korisnika"));
        
        var isAdult = DomainHelper.IsAdult(BirthDate);
        if (isAdult.HasValue && !isAdult.Value)
            validationResult.Add(EntityValidation.UserValidation.IsNotAdult);
    }

}