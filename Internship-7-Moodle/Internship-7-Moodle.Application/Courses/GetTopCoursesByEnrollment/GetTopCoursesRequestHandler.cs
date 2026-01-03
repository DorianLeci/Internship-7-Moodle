using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetTopCoursesByEnrollment;

public class GetTopCoursesRequestHandler:IRequestHandler<GetTopCoursesRequest,AppResult<GetAllResponse<TopCourseResponse>>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public GetTopCoursesRequestHandler(ICourseUnitOfWork courseUnitOfWork)
    {
        _courseUnitOfWork = courseUnitOfWork;
    }
    
    public async Task<AppResult<GetAllResponse<TopCourseResponse>>> Handle(GetTopCoursesRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<GetAllResponse<TopCourseResponse>>();
        
        var topCourses = await _courseUnitOfWork.CourseRepository.GetTopCoursesByStudentCountAsync(request.Period);

        var topCourseResponses = topCourses.Select(c => new TopCourseResponse
        {
            CourseId = c.CourseId,
            CourseName = c.CourseName,
            EnrollmentCount = c.StudentCount
        });
    
        result.SetResult(new GetAllResponse<TopCourseResponse>(topCourseResponses));

        return result;
    }
}