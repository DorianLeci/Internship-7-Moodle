using System.ComponentModel.DataAnnotations.Schema;

namespace Internship_7_Moodle.Domain.Common.Abstractions;

public abstract class BaseEntity
{
    public int Id { get; init; }
    
    [Column(TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; init; }
    
    [Column(TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }
    
    [NotMapped]
    public DateTime? DeletedAt { get; set; }
}