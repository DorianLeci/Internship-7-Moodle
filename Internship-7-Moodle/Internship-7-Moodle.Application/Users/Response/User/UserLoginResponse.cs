using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Users.Response.User;

public class UserLoginResponse
{
    public int Id { get; init; }
    public RoleEnum RoleName { get; init; }
    
}