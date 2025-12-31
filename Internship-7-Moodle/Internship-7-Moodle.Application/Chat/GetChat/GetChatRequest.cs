using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using MediatR;

namespace Internship_7_Moodle.Application.Chat.GetChat;

public record GetChatRequest(int CurrentUserId,int OtherUserId):IRequest<AppResult<ChatResponse>>
{
}