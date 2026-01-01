namespace Internship_7_Moodle.Application.DTO;

public record PublishCourseMaterialDto(string Title,string AuthorName,DateOnly? PublishDate,string Url,int CourseId)
{
    
}