using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.Course;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Persistence.Courses;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.GetAllMaterials;

public class GetAllMaterialsRequestHandler:IRequestHandler<GetAllMaterialsRequest,AppResult<GetAllResponse<MaterialResponse>>>
{
    private readonly ICourseUnitOfWork _courseUnitOfWork;

    public GetAllMaterialsRequestHandler(ICourseUnitOfWork courseUnitOfWork)
    {
        _courseUnitOfWork = courseUnitOfWork;
    }
    
    public async Task<AppResult<GetAllResponse<MaterialResponse>>> Handle(GetAllMaterialsRequest request, CancellationToken cancellationToken)
    {
        var result=new AppResult<GetAllResponse<MaterialResponse>>();

        var materials = await _courseUnitOfWork.CourseRepository.GetAllCourseMaterialsAsync(request.CourseId);

        var materialResponses = materials.Select(m => new MaterialResponse
        {
            MaterialId = m.Id,
            Title = m.Title,
            AuthorName = m.AuthorName,
            Url = m.Url,
            CreatedAt = m.CreatedAt,
        });
        
        result.SetResult(new GetAllResponse<MaterialResponse>(materialResponses));
        return result;
    }
}