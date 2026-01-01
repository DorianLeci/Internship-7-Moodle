using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.PublishCourseNotification;

public record PublishCourseNotificationCommand(string Subject,string Content,int CourseId):IRequest<AppResult<SuccessPostResponse>>
{
    public static PublishCourseNotificationCommand FromDto(PublishCourseNotificationDto dto)
    {
        return new PublishCourseNotificationCommand(dto.Subject,dto.Content,dto.CourseId);
    }
}