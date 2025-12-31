using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllCourses;

public record GetStudentCoursesRequest(int StudentId):IRequest<AppResult<GetAllResponse<CourseResponse>>>
{
}