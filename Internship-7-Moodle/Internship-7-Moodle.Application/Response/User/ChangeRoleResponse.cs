using Internship_7_Moodle.Application.Response.Common;
using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Response.User;

public class ChangeRoleResponse
{
    public int Id { get; init; }
    
    public RoleEnum? OldRoleName { get; init; }
    
    public RoleEnum? NewRoleName { get; init; }

    public string OldRoleNameCroatian => OldRoleName.ToCroatian();
    
    public string NewRoleNameCroatian => NewRoleName.ToCroatian();
    
    
}