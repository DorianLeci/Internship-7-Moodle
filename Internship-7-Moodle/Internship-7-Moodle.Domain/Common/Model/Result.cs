using System.ComponentModel.DataAnnotations;

namespace Internship_7_Moodle.Domain.Common.Model;

public class Result<TValue>
{
    public TValue? Value { get; private set; }
    public ValidationResult? ValidationResult  { get; private set; }
    
    public bool IsFailure { get; private set; }
    
    private Result(ValidationResult validationResult)
    {
        IsFailure = true;
        Value = default;
        ValidationResult = validationResult;
    }

    private Result(TValue value)
    {
        IsFailure = false;
        Value = value;
        ValidationResult = null;
    }

    public static Result<TValue> Success(TValue value) => new(value);

    public static Result<TValue> Failure(ValidationResult validationResult) => new(validationResult);
    
}