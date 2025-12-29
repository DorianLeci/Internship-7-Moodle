using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.Response.User;
using MediatR;

namespace Internship_7_Moodle.Application.Users.SendMessage;

public record SendMessageCommand(int CurrentUserId,int OtherUserId,string Text):IRequest<AppResult<PrivateMessageResponse>>
{
    public static SendMessageCommand FromDto(SendMessageDto dto)
    {
        return new SendMessageCommand(dto.CurrentUserId,dto.OtherUserId,dto.Text);
    }
}