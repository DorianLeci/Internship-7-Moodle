using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.AddStudentToCourse;

public record AddStudentToCourseCommand(int CourseId, int StudentId):IRequest<AppResult<UserResponse>>
{
    
}