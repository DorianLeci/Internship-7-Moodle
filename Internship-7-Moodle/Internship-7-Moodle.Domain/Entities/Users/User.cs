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

public partial class User:BaseEntity
{
    public const int MaxFirstNameLength = 50;
    public const int MaxLastNameLength = 50;
    public const int MaxEmailLength = 100;
    public const int MinPasswordLength = 8;
    public const int MaxAge = 90;
    
    [GeneratedRegex(@"^[\p{L}-]+$")]
    private static partial Regex NameRegexGenerated();

    [GeneratedRegex(@"^[^@]{1,}@[^@]{2,}\.[^@]{3,}$")]
    private static partial Regex EmailRegexGenerated();
    
    [GeneratedRegex("[A-Z]")]
    private static partial Regex UpperGenerated();

    [GeneratedRegex("[a-z]")]
    private static partial Regex LowerGenerated();

    [GeneratedRegex(@"^\S*$")]
    private static partial Regex NoSpacesGenerated();

    [GeneratedRegex("[!@#$%^&*]")]
    private static partial Regex SpecialGenerated();
    
    
    
    public static readonly Regex NameRegex = NameRegexGenerated();
    public static readonly Regex EmailRegex = EmailRegexGenerated();
    public static readonly Regex PasswordUpperRegex = UpperGenerated();
    public static readonly Regex PasswordLowerRegex = LowerGenerated();
    public static readonly Regex PasswordNoSpacesRegex = NoSpacesGenerated();
    public static readonly Regex PasswordSpecialRegex = SpecialGenerated();

    public string? FirstName { get; set; }
    
    public string? LastName{ get; set; }
    
    public DateOnly? BirthDate{ get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public GenderEnum? Gender { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    
    public ICollection<CourseUser> CourseEnrollments { get; set; }=new List<CourseUser>();
    
    public ICollection<PrivateMessage> SentMessages { get; set; }=new  List<PrivateMessage>();
    
    public ICollection<PrivateMessage> ReceivedMessages { get; set; }=new List<PrivateMessage>();
    
    public ICollection<Chat> ChatsAsUserA { get; set; } = new List<Chat>();
    public ICollection<Chat> ChatsAsUserB { get; set; } = new List<Chat>();

    public Result<int> Create()
    {
        var result = Validate();
        return result.HasErrors ? Result<int>.Failure(result) : Result<int>.Success(Id);
    }
    
    private ValidationResult Validate()
    {
        var validationResult = new ValidationResult();
        
        CheckFirstName(validationResult);
        
        CheckLastName(validationResult);
        
        CheckEmail(validationResult);
        
        CheckBirthDate(validationResult);
        
        CheckPassword(validationResult);
        
        return validationResult;
    }

    private void CheckFirstName(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Ime korisnika"));
            return;
        }

        if(FirstName.Length>MaxFirstNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxFirstNameLength);      
        
        if (!NameRegex.IsMatch(FirstName))
            validationResult.Add(EntityValidation.UserValidation.NameFormat);
        
        
    }
    
    private void CheckLastName(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(LastName))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Prezime korisnika"));
            return;
        }

        if(LastName.Length>MaxLastNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxLastNameLength);

        if (!NameRegex.IsMatch(LastName))
            validationResult.Add(EntityValidation.UserValidation.NameFormat);
    }

    private void CheckEmail(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(Email))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Email korisnika"));
            return;
        }
        
        if(!CheckEmailFormat(Email))
            validationResult.Add(EntityValidation.UserValidation.EmailFormat);
        
        if(Email.Length>MaxEmailLength)
            validationResult.Add(EntityValidation.UserValidation.EmailLength);
    }

    private static bool CheckEmailFormat(string email)
    {
        return EmailRegex.IsMatch(email);
    }

    private void CheckBirthDate(ValidationResult validationResult)
    {
        var isAdult = DomainHelper.IsAdult(BirthDate);
        var isTooOld = DomainHelper.IsTooOld(BirthDate);

        if (BirthDate == null)
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Datum rođenja korisnika"));
            return;
        }
        
        if (isAdult.HasValue && !isAdult.Value)
            validationResult.Add(EntityValidation.UserValidation.IsNotAdult);
        
        if(isTooOld.HasValue && isTooOld.Value)
            validationResult.Add(EntityValidation.UserValidation.IsTooOld);
    }

    private void CheckPassword(ValidationResult validationResult)
    {
        if (string.IsNullOrWhiteSpace(Password))
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemIsRequired(nameof(User),"Lozinka korisnika"));
            return;
        }
        if(Password.Length<MinPasswordLength)
            validationResult.Add(EntityValidation.UserValidation.MinPasswordLength);

        if (!PasswordUpperRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordMissingUppercase);
        
        if(!PasswordLowerRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordMissingLowercase);

        if (!PasswordNoSpacesRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordContainsSpaces);

        if (!PasswordSpecialRegex.IsMatch(Password))
            validationResult.Add(EntityValidation.UserValidation.PasswordMissingSpecialChar);        
    }


}