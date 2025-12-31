using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllCourses;

public class GetAllStudentCoursesRequestHandler:IRequestHandler<GetStudentCoursesRequest,AppResult<GetAllResponse<CourseResponse>>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    
    public GetAllStudentCoursesRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<CourseResponse>>> Handle(GetStudentCoursesRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<GetAllResponse<CourseResponse>>();
        var courses = await _userUnitOfWork.UserRepository.GetAllStudentCoursesAsync(request.StudentId);

        var studentCourseResponses = courses.Select(c => new CourseResponse
        {
            CourseId = c.Id,
            CourseName =  c.Name,
            CourseDescription = c.Description,
            Ects = c.Ects,
            ProfessorName = c.Owner.FirstName+" "+c.Owner.LastName
        });
        
        result.SetResult(new GetAllResponse<CourseResponse>(studentCourseResponses));

        return result;
    }
}