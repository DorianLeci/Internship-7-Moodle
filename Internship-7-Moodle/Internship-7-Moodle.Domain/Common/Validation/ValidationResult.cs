namespace Internship_7_Moodle.Domain.Common.Validation;

public class ValidationResult
{
    private readonly List<ValidationItem> _validationItems = new();
    public IReadOnlyCollection<ValidationItem> ValidationItems => _validationItems;
    
    public bool HasInfo=> _validationItems.Any(vi=>vi.ValidationSeverity==ValidationSeverity.Info);
    public bool HasWarnings => _validationItems.Any(vi => vi.ValidationSeverity == ValidationSeverity.Warning);
    public bool HasErrors => _validationItems.Any(vi => vi.ValidationSeverity == ValidationSeverity.Error);
    
    public void Add(ValidationItem validationItem)=>_validationItems.Add(validationItem);
    
    public void AddRange(IEnumerable<ValidationItem> validationItems)=>_validationItems.AddRange(validationItems);
    
}