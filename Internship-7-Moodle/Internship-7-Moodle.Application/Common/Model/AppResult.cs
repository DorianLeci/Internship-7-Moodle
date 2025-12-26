using Internship_7_Moodle.Domain.Common.Validation;

namespace Internship_7_Moodle.Application.Common.Model;

public class AppResult<TValue> where TValue : class,new()
{
    private readonly List<ValidationItem> _infos = new();
    private readonly List<ValidationItem> _warnings = new();
    private readonly List<ValidationItem> _errors = new();
    
    public IReadOnlyCollection<ValidationItem> Infos => _infos.AsReadOnly();
    public IReadOnlyCollection<ValidationItem> Warnings => _warnings.AsReadOnly();
    public IReadOnlyCollection<ValidationItem> Errors => _errors.AsReadOnly();

    public bool IsFailure => _errors.Count != 0;

    public TValue? Value { get; private set; } = null;

    public void SetResult(TValue value)
    {
        Value = value;
    }
    
    private void AddError(ValidationResult validationResult)=>_errors.AddRange(validationResult.ValidationItems.Where(item=>item.ValidationSeverity == ValidationSeverity.Error));
    private void AddWarning(ValidationResult validationResult)=>_warnings.AddRange(validationResult.ValidationItems.Where(item=>item.ValidationSeverity == ValidationSeverity.Warning));
    private void AddInfo(ValidationResult validationResult)=>_infos.AddRange(validationResult.ValidationItems.Where(item=>item.ValidationSeverity == ValidationSeverity.Info));

    public void SetValidationResult(ValidationResult validationResult)
    {
        AddError(validationResult);
        AddInfo(validationResult);
        AddWarning(validationResult);
    }
}