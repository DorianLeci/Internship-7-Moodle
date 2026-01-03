using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Common.Helper;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetCourseCount;

public record GetCourseCountRequest(PeriodEnum Period):IRequest<AppResult<CourseCountResponse>>
{
    
}