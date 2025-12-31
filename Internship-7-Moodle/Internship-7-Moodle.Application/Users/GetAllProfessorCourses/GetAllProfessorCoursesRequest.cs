using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllProfessorCourses;

public record GetAllProfessorCoursesRequest(int ProfessorId):IRequest<AppResult<GetAllResponse<CourseResponse>>>
{
    
}