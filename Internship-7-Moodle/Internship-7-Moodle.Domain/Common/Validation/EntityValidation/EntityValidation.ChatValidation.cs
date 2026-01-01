namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class ChatValidation
    {
        public static ValidationItem ItemMustBeDifferent(string entityName, string message)
        {
            return new ValidationItem(
                ValidationType.BussinessRule,
                ValidationSeverity.Error,
                $"{entityName}_ItemMustBeDifferent",
                $"{message}");   
        }
    }
}