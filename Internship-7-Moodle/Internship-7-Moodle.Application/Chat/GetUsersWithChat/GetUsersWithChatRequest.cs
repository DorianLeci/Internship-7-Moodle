using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Enumerations;
using MediatR;

namespace Internship_7_Moodle.Application.Chat.GetUsersWithChat;

public record GetUsersWithChatRequest(int UserId,RoleEnum? RoleFilter):IRequest<AppResult<GetAllResponse<UserResponse>>>
{
    public static GetUsersWithChatRequest FromDto(GetUserChatDto dto)
    {
        return new GetUsersWithChatRequest(dto.UserId,dto.RoleFilter);
    }  
}