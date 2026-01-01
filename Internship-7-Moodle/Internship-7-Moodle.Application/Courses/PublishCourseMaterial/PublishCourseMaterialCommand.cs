using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using MediatR;

namespace Internship_7_Moodle.Application.Courses.PublishCourseMaterial;

public record PublishCourseMaterialCommand(string Title,string AuthorName,DateOnly? PublishDate,string Url,int CourseId):IRequest<AppResult<SuccessPostResponse>>
{
    public static PublishCourseMaterialCommand FromDto(PublishCourseMaterialDto dto)
    {
        return new PublishCourseMaterialCommand(dto.Title, dto.AuthorName,dto.PublishDate,dto.Url,dto.CourseId);
    }
}