using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetAllStudentsEnrolled;

public class GetAllStudentsEnrolledRequestHandler:IRequestHandler<GetAllStudentsEnrolledRequest,AppResult<GetAllResponse<UserResponse>>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public GetAllStudentsEnrolledRequestHandler(ICourseUnitOfWork courseUnitOfWork)
    {
        _courseUnitOfWork = courseUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<UserResponse>>> Handle(GetAllStudentsEnrolledRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<UserResponse>>();

        var studentsEnrolled = await _courseUnitOfWork.CourseRepository.GetAllStudentsEnrolledAsync(request.CourseId);

        var studentResponses = studentsEnrolled
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