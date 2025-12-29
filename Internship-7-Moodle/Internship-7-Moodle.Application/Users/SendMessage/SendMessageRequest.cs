using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Users.Response.User;
using MediatR;

namespace Internship_7_Moodle.Application.Users.SendMessage;

public record SendMessageRequest(int CurrentUserId,int OtherUserId,string Text):IRequest<AppResult<PrivateMessageResponse>>
{
    public static SendMessageRequest FromDto(SendMessageDto dto)
    {
        return new SendMessageRequest(dto.CurrentUserId,dto.OtherUserId,dto.Text);
    }
}