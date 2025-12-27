using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetAllNotifications;

public record GetAllNotificationsRequest(int CourseId): IRequest<AppResult<GetAllResponse<NotificationResponse>>>
{
    public static GetAllNotificationsRequest FromDto(GetNotificationDto dto)
    {
        return new GetAllNotificationsRequest(dto.courseId);
    }
}