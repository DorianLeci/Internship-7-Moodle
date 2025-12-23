namespace Internship_7_Moodle.Presentation.InputValidation;

public class PresentationValidationResult<T>
{
    public bool Successful { get; private set; }
    public string? Message { get; private set; }
    public T Value{get; private set;}
    
    public bool IsCancelled { get; private set; }

    private PresentationValidationResult(bool successful, string? message, T value,bool isCancelled)
    {
        Successful = successful;
        Message = message;
        Value = value;
        IsCancelled = isCancelled;
    }
    
    public static PresentationValidationResult<T> Success(T value=default!)=>new(true,null, value,false);

    public static PresentationValidationResult<T> Error(string message) => new(false, message, default!,false);

    public static PresentationValidationResult<T> Cancelled() => new(false, null, default!, true);
}