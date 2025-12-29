using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response.User;
using MediatR;

namespace Internship_7_Moodle.Application.Users.GetChat;

public record GetOrCreateChatRequest(int CurrentUserId,int OtherUserId):IRequest<AppResult<ChatResponse>>
{
}