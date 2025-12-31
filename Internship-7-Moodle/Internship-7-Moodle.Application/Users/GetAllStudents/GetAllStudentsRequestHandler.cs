using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetAllStudents;

public class GetAllStudentsRequestHandler:IRequestHandler<GetAllStudentsRequest,AppResult<GetAllResponse<UserResponse>>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;

    public GetAllStudentsRequestHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    
    
    public async Task<AppResult<GetAllResponse<UserResponse>>> Handle(GetAllStudentsRequest request, CancellationToken cancellationToken)
    {
        var result = new AppResult<GetAllResponse<UserResponse>>();

        var students = await _userUnitOfWork.UserRepository.GetAllStudentsAsync();

        var studentResponses = students
            .Select(s => new UserResponse()
            {
                Id = s.Id,
                FirstName = s.FirstName!,
                LastName = s.LastName!,
                RoleName = s.Role.RoleName,
            });
        
        result.SetResult(new GetAllResponse<UserResponse>(studentResponses));
        
        return result;
    }
}