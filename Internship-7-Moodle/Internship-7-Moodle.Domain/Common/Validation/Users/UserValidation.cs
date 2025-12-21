using Internship_7_Moodle.Domain.Entities.Users;

namespace Internship_7_Moodle.Domain.Common.Validation.Users;

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
            $"{Prefix}_{nameof(User.Email)}",
            $"Email korisnik ne smije biti duži od {User.MaxEmailLength} znakova");
    }

}