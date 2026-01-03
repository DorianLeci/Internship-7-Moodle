using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetCourseCount;

public class GetCourseCountRequestHandler:IRequestHandler<GetCourseCountRequest,AppResult<CourseCountResponse>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public GetCourseCountRequestHandler(ICourseUnitOfWork courseUnitOfWork)
    {
        _courseUnitOfWork = courseUnitOfWork;
    }
    
    public async Task<AppResult<CourseCountResponse>> Handle(GetCourseCountRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<CourseCountResponse>();

        var courseCount = await _courseUnitOfWork.CourseRepository.GetCourseCountAsync(request.Period);

        var response = new CourseCountResponse
        {
            CourseCount=courseCount
        };
        
        result.SetResult(response);
        
        return result;
    }
}