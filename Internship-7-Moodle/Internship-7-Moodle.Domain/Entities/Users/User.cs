using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.Users;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Enumerations;
namespace Internship_7_Moodle.Domain.Entities.Users;

public class User:BaseEntity
{
    public const int MaxFirstNameLength = 30;
    public const int MaxLastNameLength = 30;
    public const int MaxEmailLength = 50;
        
    public string? FirstName{ get; set; }
    
    public string? LastName{ get; set; }
    
    public DateOnly? BirthDate{ get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public GenderEnum? Gender { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public ICollection<CourseUser> CourseStudents { get; set; }

    public async Task<ValidationResult> Validate()
    {
        var validationResult = new ValidationResult();
        
        if(FirstName?.Length>MaxFirstNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxFirstNameLength);
        
        if(FirstName?.Length>MaxLastNameLength)
            validationResult.Add(EntityValidation.UserValidation.MaxLastNameLength);
        
        if(Email.Length>MaxEmailLength)
            validationResult.Add(EntityValidation.UserValidation.EmailLength);
        
        return validationResult;
    }

}