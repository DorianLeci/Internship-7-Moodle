using Internship_7_Moodle.Application.Response.Common;
using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Response.User;

public class CountByRoleResponse
{
    public RoleEnum RoleName { get; init; }
    
    public int Count { get; init; }       
    
    public string RoleNameCroatian => RoleName.ToCroatian();
}