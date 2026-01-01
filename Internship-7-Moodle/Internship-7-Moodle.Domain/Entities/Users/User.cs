using System.Text.RegularExpressions;
using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Model;
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
    
}