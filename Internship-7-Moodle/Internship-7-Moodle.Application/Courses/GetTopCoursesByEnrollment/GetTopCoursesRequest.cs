using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetTopCoursesByEnrollment;

public record GetTopCoursesRequest(PeriodEnum Period):IRequest<AppResult<GetAllResponse<TopCourseResponse>>>
{
    
}