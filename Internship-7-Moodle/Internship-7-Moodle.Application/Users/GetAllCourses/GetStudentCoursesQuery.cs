using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.LoginUser;
using Internship_7_Moodle.Application.Users.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllCourses;

public record GetStudentCoursesQuery(int StudentId):IRequest<AppResult<GetAllResponse<StudentCourseResponse>>>
{
    public static GetStudentCoursesQuery FromDto(StudentCoursesDto dto)
    {
        return new GetStudentCoursesQuery(dto.StudentId);
    }
}