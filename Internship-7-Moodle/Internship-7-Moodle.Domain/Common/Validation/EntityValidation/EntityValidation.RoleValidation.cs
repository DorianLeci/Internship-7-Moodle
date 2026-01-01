using Internship_7_Moodle.Domain.Entities.Roles;

namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class RoleValidation
    {
        private const string Prefix = nameof(Role);
        
        public static readonly ValidationItem RoleMustExist= new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_RoleMustExist",
            $"Uloga ne postoji u bazi podataka");
    }   
}
