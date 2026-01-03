using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Courses.AddStudentToCourse;
using Internship_7_Moodle.Application.Courses.GetAllMaterials;
using Internship_7_Moodle.Application.Courses.GetAllNotifications;
using Internship_7_Moodle.Application.Courses.GetAllStudentsEnrolled;
using Internship_7_Moodle.Application.Courses.GetCourseCount;
using Internship_7_Moodle.Application.Courses.GetTopCoursesByEnrollment;
using Internship_7_Moodle.Application.Courses.PublishCourseMaterial;
using Internship_7_Moodle.Application.Courses.PublishCourseNotification;
using Internship_7_Moodle.Application.Courses.StudentsNotEnrolled;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Response.Course;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Enumerations;
using MediatR;

namespace Internship_7_Moodle.Presentation.Actions;

public class CourseActions
{
    private readonly IMediator _mediator;

    public CourseActions(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IEnumerable<NotificationResponse>> GetAllNotificationsAsync(int courseId,RoleEnum viewerRole)
    {
        
        var result = await _mediator.Send(new GetAllNotificationsRequest(courseId,viewerRole));

        if (result.Value == null)
            return [];

        var courses = result.Value.Entities;

        return courses;
    }

    public async Task<IEnumerable<MaterialResponse>> GetAllMaterialsAsync(int courseId)
    {
        var result = await _mediator.Send(new GetAllMaterialsRequest(courseId));

        if (result.Value == null)
            return [];

        var materials = result.Value.Entities;

        return materials;        
    }
    
    public async Task<IEnumerable<UserResponse>> GetAllStudentsEnrolledAsync(int courseId)
    {
        var result = await _mediator.Send(new GetAllStudentsEnrolledRequest(courseId));

        if (result.Value == null)
            return [];

        var studentsEnrolled = result.Value.Entities;

        return studentsEnrolled;        
    }
    
    public async Task<IEnumerable<UserResponse>> GetAllStudentsNotEnrolledAsync(int courseId)
    {
        var result = await _mediator.Send(new StudentsNotEnrolledRequest(courseId));

        if (result.Value == null)
            return [];

        var studentsNotEnrolled = result.Value.Entities;

        return studentsNotEnrolled;        
    }

    public async Task<AppResult<SuccessPostResponse>> PublishCourseNotificationAsync(string subject, string content, int courseId)
    {
        var courseNotificationDto=new PublishCourseNotificationDto(subject,content,courseId);
        
        return await _mediator.Send(PublishCourseNotificationCommand.FromDto(courseNotificationDto));
    }
    
    public async Task<AppResult<SuccessPostResponse>> PublishCourseMaterialAsync(string title,string authorName,DateOnly? publishDate,string Url,int courseId)
    {
        var courseMaterialDto=new PublishCourseMaterialDto(title,authorName,publishDate,Url,courseId);
        
        return await _mediator.Send(PublishCourseMaterialCommand.FromDto(courseMaterialDto));
    }

    public async Task<AppResult<UserResponse>> AddStudentToCourseAsync(int courseId, int studentId)
    {
        return await _mediator.Send(new AddStudentToCourseCommand(courseId, studentId));
    }
    
    public async Task<CourseCountResponse> GetCourseCountAsync(PeriodEnum period)
    {
        var result=await _mediator.Send(new GetCourseCountRequest(period));

        return result.Value ?? new CourseCountResponse { CourseCount = 0 };
    }
    
    public async Task<IEnumerable<TopCourseResponse>> GetTopCoursesByEnrollmentAsync(PeriodEnum period)
    {
        var result = await _mediator.Send(new GetTopCoursesRequest(period));

        if (result.Value == null)
            return [];

        var topCourseResponses = result.Value.Entities;

        return topCourseResponses;
    }
}