using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllProfessorCourses;

public class GetAllProfessorCoursesRequestHandler:IRequestHandler<GetAllProfessorCoursesRequest,AppResult<GetAllResponse<CourseResponse>>>
{    
    private readonly IUserUnitOfWork _userUnitOfWork;
    
    public GetAllProfessorCoursesRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<CourseResponse>>> Handle(GetAllProfessorCoursesRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<GetAllResponse<CourseResponse>>();
        var courses = await _userUnitOfWork.UserRepository.GetAllProfessorCoursesAsync(request.ProfessorId);

        var professorCourseResponses = courses.Select(c => new CourseResponse
        {
            CourseId = c.Id,
            CourseName =  c.Name,
            CourseDescription = c.Description,
            Ects = c.Ects,
        });
        
        result.SetResult(new GetAllResponse<CourseResponse>(professorCourseResponses));

        return result;
    }
}