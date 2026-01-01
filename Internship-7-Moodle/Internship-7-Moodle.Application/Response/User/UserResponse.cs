using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Response.User;

public class UserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    public string FullName=> $"{FirstName} {LastName}";
    
    public RoleEnum? RoleName { get; set; } 
}