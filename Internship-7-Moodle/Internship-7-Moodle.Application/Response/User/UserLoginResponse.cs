using Internship_7_Moodle.Application.Response.Common;
using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Response.User;

public class UserLoginResponse
{
    public int Id { get; init; }
    public RoleEnum RoleName { get; init; }
    
    public string FirstName { get; init; } = null!;
    
    public string LastName { get; init; } = null!;
    
    public string FullName=> $"{FirstName} {LastName}";

    public string RoleNameCroatian => RoleName.ToCroatian();
}