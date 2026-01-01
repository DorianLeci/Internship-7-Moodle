using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Courses.Materials;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.PublishCourseMaterial;

public class PublishCourseMaterialCommandHandler:IRequestHandler<PublishCourseMaterialCommand,AppResult<SuccessPostResponse>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public PublishCourseMaterialCommandHandler(ICourseUnitOfWork unitOfWork)
    {
        _courseUnitOfWork = unitOfWork;
    }
    
    public async Task<AppResult<SuccessPostResponse>> Handle(PublishCourseMaterialCommand request, CancellationToken cancellationToken)
    {
        var result = new AppResult<SuccessPostResponse>();
        var validationResult = new ValidationResult();

        var newMaterial = new CourseMaterial
        {
            Title = request.Title,
            AuthorName = request.AuthorName,
            PublishedDate = request.PublishDate,
            Url = request.Url,
        };
        
        var domainResult= newMaterial.Create();
        
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

        newMaterial.Course = course!;
        
        await _courseUnitOfWork.CourseMaterialRepository.InsertAsync(newMaterial);
        await _courseUnitOfWork.SaveAsync();
        
        result.SetResult(new SuccessPostResponse(newMaterial.Id));
        return result;

    }
}