using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.StudentsNotEnrolled;

public record StudentsNotEnrolledRequest(int CourseId):IRequest<AppResult<GetAllResponse<UserResponse>>>
{
    
}