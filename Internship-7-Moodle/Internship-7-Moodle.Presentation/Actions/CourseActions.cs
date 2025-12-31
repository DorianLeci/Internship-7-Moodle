using Internship_7_Moodle.Application.Courses.GetAllMaterials;
using Internship_7_Moodle.Application.Courses.GetAllNotifications;
using Internship_7_Moodle.Application.Response.Course;
using MediatR;

namespace Internship_7_Moodle.Presentation.Actions;

public class CourseActions
{
    private readonly IMediator _mediator;

    public CourseActions(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IEnumerable<NotificationResponse>> GetAllNotificationsAsync(int courseId)
    {
        
        var result = await _mediator.Send(new GetAllNotificationsRequest(courseId));

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
}