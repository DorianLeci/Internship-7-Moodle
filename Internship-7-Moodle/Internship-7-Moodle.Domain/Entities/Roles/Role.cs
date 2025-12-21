using Internship_7_Moodle.Domain.Common.Abstractions;

namespace Internship_7_Moodle.Domain.Entities.Roles;

public class Role:BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
}