using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Courses;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.AddStudentToCourse;

public class AddStudentToCourseCommandHandler:IRequestHandler<AddStudentToCourseCommand,AppResult<UserResponse>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;
    private readonly IUserUnitOfWork _userUnitOfWork;

    public AddStudentToCourseCommandHandler(ICourseUnitOfWork courseUnitOfWork, IUserUnitOfWork userUnitOfWork)
    {
        _courseUnitOfWork = courseUnitOfWork;
        _userUnitOfWork = userUnitOfWork;
    }
    
    public async Task<AppResult<UserResponse>> Handle(AddStudentToCourseCommand request, CancellationToken cancellationToken)
    {
        var result=new AppResult<UserResponse>();
        var validationResult = new ValidationResult();
        
        var course = await _courseUnitOfWork.CourseRepository.GetByIdAsync(request.CourseId);
        
        if(course == null)
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(Course),"Kolegij"));
        
        var user=await _userUnitOfWork.UserRepository.GetByIdAsync(request.StudentId);
        
        if(user == null)
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(User),"Student"));
        
        if (validationResult.HasErrors)
        {
            result.SetValidationResult(validationResult);
            return result;
        }

        var courseUser = new CourseUser
        {
            CourseId = request.CourseId,
            UserId = request.StudentId
        };

        await _courseUnitOfWork.CourseUserRepository.InsertAsync(courseUser);

        await _courseUnitOfWork.SaveAsync();

        var userResponse = new UserResponse
        {
            Id=request.StudentId,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
        
        result.SetResult(userResponse);
        return result;
    }
}