using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.DTO;

public record GetUserChatDto(int UserId,RoleEnum? RoleFilter=null)
{
    
}