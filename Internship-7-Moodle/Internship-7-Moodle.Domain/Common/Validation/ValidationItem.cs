namespace Internship_7_Moodle.Domain.Common.Validation;

public class ValidationItem
{
    public ValidationType ValidationType { get; init; }
    
    public ValidationSeverity ValidationSeverity { get; init; }
    
    public string Code { get; init; }
    
    public string? Message { get; init; }

    public ValidationItem(ValidationType validationType, ValidationSeverity validationSeverity, string code,string? message)
    {
        ValidationType = validationType;
        ValidationSeverity = validationSeverity;
        Code = code;
        Message = message;
    }
    
}