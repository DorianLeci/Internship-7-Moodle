using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetAllNotifications;

public class GetAllNotificationsRequestHandler:IRequestHandler<GetAllNotificationsRequest,AppResult<GetAllResponse<NotificationResponse>>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public GetAllNotificationsRequestHandler(ICourseUnitOfWork courseUnitOfWork)
    {
        _courseUnitOfWork = courseUnitOfWork;
    }
    public async Task<AppResult<GetAllResponse<NotificationResponse>>> Handle(GetAllNotificationsRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<GetAllResponse<NotificationResponse>>();

        var notifications = await _courseUnitOfWork.CourseRepository.GetAllCourseNotificationsAsync(request.CourseId);

        var notificationResponses = notifications.Select(n=>new NotificationResponse
            {
                NotificationId = n.Id,
                Subject = n.Subject,
                Content = n.Content,
                ProfessorName = n.Course.Owner.FirstName+" "+n.Course.Owner.LastName,
                CreatedAt =  n.CreatedAt,
            }
        );
        
        result.SetResult(new GetAllResponse<NotificationResponse>(notificationResponses));
        return result;
    }
}