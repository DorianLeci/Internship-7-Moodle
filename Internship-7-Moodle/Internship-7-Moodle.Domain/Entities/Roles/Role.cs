using Internship_7_Moodle.Domain.Abstractions;

namespace Internship_7_Moodle.Domain.Entities.Roles;

public class Role:BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
}