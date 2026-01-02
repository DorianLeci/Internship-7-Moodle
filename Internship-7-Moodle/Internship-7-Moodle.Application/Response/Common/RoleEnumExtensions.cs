using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.Response.Common;

public static class RoleEnumExtensions
{
    public static string ToCroatian(this RoleEnum? role) => role switch
    {
        RoleEnum.Admin => "Administrator",
        RoleEnum.Professor => "Profesor",
        RoleEnum.Student => "Student",
        null => "-",
        _ => "Nepoznato"
    };
    
    public static string ToCroatian(this RoleEnum role) => role switch
    {
        RoleEnum.Admin => "Administrator",
        RoleEnum.Professor => "Profesor",
        RoleEnum.Student => "Student",
        _ => "Nepoznato"
    };
}