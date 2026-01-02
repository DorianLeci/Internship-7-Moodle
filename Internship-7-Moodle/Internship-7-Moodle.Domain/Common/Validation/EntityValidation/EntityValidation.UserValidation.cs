using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class UserValidation
    {
        private const string Prefix = nameof(User);

        public static readonly ValidationItem MaxFirstNameLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_{nameof(User.MaxFirstNameLength)}",
            $"Ime korisnika ne smije biti duže od {User.MaxFirstNameLength} znakova");

        public static readonly ValidationItem MaxLastNameLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_{nameof(User.MaxLastNameLength)}",
            $"Prezime korisnika ne smije biti duže od {User.MaxLastNameLength} znakova");

        public static readonly ValidationItem EmailLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_EmailLength",
            $"Email korisnika ne smije biti duži od {User.MaxEmailLength} znakova");
        
        public static readonly ValidationItem EmailFormat = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_EmailFormat",
            $"Format emaila nije ispravan");
        
        public static readonly ValidationItem NameFormat = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_NameFormat",
            $"Format imena nije ispravan");


        public static readonly ValidationItem IsNotAdult = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"$\"{{Prefix}}_isNotAdult",
            $"Korisnik mora imati bar 18 godina");
        
        public static readonly ValidationItem IsTooOld = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"$\"{{Prefix}}_isTooOld",
            $"Korisnik ne smije biti stariji od {User.MaxAge} godina");
        
        public static readonly ValidationItem EmailNotUnique = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"$\"{{Prefix}}_EmailNotUnique",
            $"Email mora biti jedinstven");
        
        public static readonly ValidationItem EmailSameAsOld = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"$\"{{Prefix}}_EmailSameAsOld",
            $"Email je isti kao prethodni");

        public static readonly ValidationItem InvalidPassword = new ValidationItem(
            ValidationType.Authentication,
            ValidationSeverity.Error,
            $"$\"{{Prefix}}_InvalidPassword",
            $"Lozinka nije ispravna");
        
        
        public static readonly ValidationItem MinPasswordLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_{nameof(User.MinPasswordLength)}",
            $"Lozinka ne smije biti kraća od {User.MinPasswordLength} znakova");
        
        
        public static readonly ValidationItem PasswordMissingUppercase =
            new ValidationItem(
                ValidationType.BussinessRule,
                ValidationSeverity.Error,
                $"{Prefix}_PasswordMissingUppercase",
                "Lozinka mora sadržavati barem jedno veliko slovo."
            );

        public static readonly ValidationItem PasswordMissingLowercase =
            new ValidationItem(
                ValidationType.BussinessRule,
                ValidationSeverity.Error,
                $"{Prefix}_PasswordMissingLowercase",
                "Lozinka mora sadržavati barem jedno malo slovo."
            );

        public static readonly ValidationItem PasswordMissingSpecialChar =
            new ValidationItem(
                ValidationType.BussinessRule,
                ValidationSeverity.Error,
                $"{Prefix}_PasswordMissingSpecialChar",
                "Lozinka mora sadržavati barem jedan specijalni znak."
            );

        public static readonly ValidationItem PasswordContainsSpaces =
            new ValidationItem(
                ValidationType.BussinessRule,
                ValidationSeverity.Error,
                $"{Prefix}_PasswordContainsSpaces",
                "Lozinka ne smije sadržavati razmake."
            );
        
        public static readonly ValidationItem ProfessorDeletionError = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_ProfessorHasActiveCourses",
            $"Profesor drži kolegije i ne može biti obrisan.");
        
        public static readonly ValidationItem ProfessorRoleChangeError = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_ProfessorHasActiveCourses",
            $"Profesor drži kolegije te ne može postati student.");

        
    }

}