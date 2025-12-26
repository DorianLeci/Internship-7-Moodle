using Internship_7_Moodle.Domain.Common.Abstractions;
using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Domain.Entities.Roles;

public class Role:BaseEntity
{
    public const int MaxDescriptionLength = 200;
    public RoleEnum RoleName { get; set; }
    
    public string Description { get; set; }
}