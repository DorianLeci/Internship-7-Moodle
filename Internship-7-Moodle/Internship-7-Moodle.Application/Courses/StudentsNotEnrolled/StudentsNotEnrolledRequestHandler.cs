using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.StudentsNotEnrolled;

public class StudentsNotEnrolledRequestHandler:IRequestHandler<StudentsNotEnrolledRequest,AppResult<GetAllResponse<UserResponse>>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public StudentsNotEnrolledRequestHandler(ICourseUnitOfWork courseUnitOfWork)
    {
        _courseUnitOfWork = courseUnitOfWork;
    }
    
    public async Task<AppResult<GetAllResponse<UserResponse>>> Handle(StudentsNotEnrolledRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<UserResponse>>();

        var studentsNotEnrolled = await _courseUnitOfWork.CourseRepository.GetAllStudentsNotEnrolledAsync(request.CourseId);
        
        var studentResponses = studentsNotEnrolled
            .Select(s => new UserResponse
            {
                Id = s.Id,
                FirstName = s.FirstName!,
                LastName = s.LastName!,
            });
        
                
        result.SetResult(new GetAllResponse<UserResponse>(studentResponses));
        
        return result;
        
    }
}