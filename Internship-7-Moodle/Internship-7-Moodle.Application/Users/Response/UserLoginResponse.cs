using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Users.Response;

public class UserLoginResponse
{
    public int? Id { get; init; }
    public RoleEnum? RoleName { get; init; }
    
    public UserLoginResponse(int? id,RoleEnum? roleName)
    {
        Id = id;
        RoleName = roleName;
    }

    public UserLoginResponse()
    {
        
    }
    
}