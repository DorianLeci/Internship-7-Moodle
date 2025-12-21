namespace Internship_7_Moodle.Domain.Abstractions;

public abstract class BaseEntity
{
    public int Id { get; init; }
    
    public DateTime CreatedAt { get; init; }
    
    public DateTime UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
}