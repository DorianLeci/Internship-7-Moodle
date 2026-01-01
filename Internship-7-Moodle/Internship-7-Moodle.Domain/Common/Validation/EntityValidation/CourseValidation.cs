using Internship_7_Moodle.Domain.Entities.Courses;

namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class CourseValidation
    {
        private const string CourseNotificationPrefix = nameof(CourseNotification);

        public static readonly ValidationItem MaxSubjectLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{CourseNotificationPrefix}_{nameof(CourseNotification.SubjectMaxLength)}",
            $"Naslov obavijesti ne smije biti duži od {CourseNotification.SubjectMaxLength} znakova");
        
        public static readonly ValidationItem MaxContentLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{CourseNotificationPrefix}_{nameof(CourseNotification.ContentMaxLength)}",
            $"Sadržaj obavijesti ne smije biti duži od {CourseNotification.ContentMaxLength} znakova");

    }
}