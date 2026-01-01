using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;
using CourseNotification = Internship_7_Moodle.Domain.Entities.Courses.Notifications.CourseNotification;

namespace Internship_7_Moodle.Application.Courses.PublishCourseNotification;

public class PublishCourseNotificationHandler:IRequestHandler<PublishCourseNotificationCommand,AppResult<SuccessPostResponse>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public PublishCourseNotificationHandler(ICourseUnitOfWork unitOfWork)
    {
        _courseUnitOfWork = unitOfWork;
    }
    
    public async Task<AppResult<SuccessPostResponse>> Handle(PublishCourseNotificationCommand request, CancellationToken cancellationToken)
    {
        var result = new AppResult<SuccessPostResponse>();
        var validationResult = new ValidationResult();

        var newNotification = new CourseNotification
        {
            Subject = request.Subject,
            Content = request.Content,
        };
        
        var domainResult= newNotification.Create();
        
        if (domainResult.IsFailure)
            validationResult.AddRange(domainResult.ValidationResult!.ValidationItems);
        
        var course = await _courseUnitOfWork.CourseRepository.GetByIdAsync(request.CourseId);
        
        if (course == null)
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(Course),"Kolegij"));
        
        if (validationResult.HasErrors)
        {
            result.SetValidationResult(validationResult);
            return result;
        }

        newNotification.Course = course!;
        
        await _courseUnitOfWork.CourseNotificationRepository.InsertAsync(newNotification);
        await _courseUnitOfWork.SaveAsync();
        
        result.SetResult(new SuccessPostResponse(newNotification.Id));
        return result;

    }
}