using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Users.Response.User;

public class UserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }  
    public RoleEnum? RoleName { get; set; } 
}