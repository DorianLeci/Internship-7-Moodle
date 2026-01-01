using Internship_7_Moodle.Domain.Entities.Courses;

namespace Internship_7_Moodle.Domain.Common.Validation.EntityValidation;

public static partial class EntityValidation
{
    public static class CourseValidation
    {
        private const string CourseNotificationPrefix = nameof(CourseNotification);
        private const string CourseMaterialPrefix = nameof(CourseMaterial);

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
        
        public static readonly ValidationItem MaxTitleLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{CourseMaterialPrefix}_{nameof(CourseMaterial.MaxTitleLength)}",
            $"Naslov materijala ne smije biti duži od {CourseMaterial.MaxTitleLength} znakova");
        
        public static readonly ValidationItem MaxAuthorNameLength = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{CourseMaterialPrefix}_{nameof(CourseMaterial.MaxAuthorNameLength)}",
            $"Ime autora ne smije biti duže od {CourseMaterial.MaxTitleLength} znakova");
        
        public static readonly ValidationItem PublishedDateTooNew = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{CourseMaterialPrefix}_PublishedDateTooNew",
            $"Datum objave ne može biti u budućnosti");
        
        public static readonly ValidationItem InvalidUrl = new ValidationItem(
            ValidationType.BussinessRule,
            ValidationSeverity.Error,
            $"{CourseMaterialPrefix}_InvalidUrl",
            $"Format url-a nije ispravan");
        
    }
}