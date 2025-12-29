using Internship_7_Moodle.Domain.Entities.Messages;

namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class MessageValidation
    {
        private const string Prefix = nameof(PrivateMessage);

        public static readonly ValidationItem MaxTextLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{Prefix}_{nameof(PrivateMessage.MaxTextLength)}",
            $"Sadržaj poruke ne smije biti duži od {PrivateMessage.MaxTextLength} znakova");
    }
}    