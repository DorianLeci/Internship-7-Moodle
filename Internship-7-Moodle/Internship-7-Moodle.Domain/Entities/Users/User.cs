using Internship_7_Moodle.Domain.Abstractions;
using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Enumerations;
namespace Internship_7_Moodle.Domain.Entities.Users;

public class User:BaseEntity
{
    public string FirstName{ get; set; }
    
    public string LastName{ get; set; }
    
    public DateOnly BirthDate{ get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public GenderEnum Gender { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }

}