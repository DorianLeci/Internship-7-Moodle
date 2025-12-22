namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class CommonValidation
    {
        public static ValidationItem ItemIsRequired(string entityName, string propertyName)
        {
            return new ValidationItem(
                ValidationType.BussinessRule,
                ValidationSeverity.Error,
                $"{entityName}_ItemIsRequired",
                $"{propertyName} je obavezno polje");            
        }

            
    }

}