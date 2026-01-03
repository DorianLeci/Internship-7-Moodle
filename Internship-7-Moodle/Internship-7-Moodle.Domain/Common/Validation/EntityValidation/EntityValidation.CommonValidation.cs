namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class CommonValidation
    {
        public static ValidationItem ItemIsRequired(string entityName, string propertyName)
        {
            return new ValidationItem(
                ValidationType.BusinessRule,
                ValidationSeverity.Error,
                $"{entityName}_ItemIsRequired",
                $"{propertyName} je obavezno polje");            
        }
        
        public static ValidationItem ItemMustExist(string entityName, string propertyName)
        {
            return new ValidationItem(
                ValidationType.Infrastructure,
                ValidationSeverity.Error,
                $"{entityName}_ItemMustExist",
                $"{propertyName} ne postoji");            
        }
        
    }

}