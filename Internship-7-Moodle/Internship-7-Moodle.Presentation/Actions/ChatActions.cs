using Internship_7_Moodle.Application.Chat.GetChat;
using Internship_7_Moodle.Application.Chat.GetUsersWithChat;
using Internship_7_Moodle.Application.Chat.GetUsersWithoutChat;
using Internship_7_Moodle.Application.Chat.SendMessage;
using Internship_7_Moodle.Application.Chat.UpdateUnreadMessage;
using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Application.Response.Chat;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Enumerations;
using MediatR;

namespace Internship_7_Moodle.Presentation.Actions;

public class ChatActions
{
    private readonly IMediator _mediator;

    public ChatActions(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IEnumerable<UserResponse>> GetAllUsersWithoutChatAsync(int userId,RoleEnum? roleFilter=null)
    {
        var dto=new GetUserChatDto(userId,roleFilter);
        var result = await _mediator.Send(GetUsersWithoutChatRequest.FromDto(dto));

        if (result.Value == null)
            return [];
        
        var  users = result.Value.Entities;
        
        return users;

    }
    
    public async Task<IEnumerable<UserResponse>> GetAllUsersWithChatAsync(int userId,RoleEnum? roleFilter=null)
    {
        var dto=new GetUserChatDto(userId,roleFilter);
        var result = await _mediator.Send(GetUsersWithChatRequest.FromDto(dto));

        if (result.Value == null)
            return [];
        
        var  users = result.Value.Entities;
        
        return users;

    }

    public async Task<AppResult<ChatResponse>> GetChatAsync(int currentUserId, int otherUserId)
    {
        return await _mediator.Send(new GetChatRequest(currentUserId, otherUserId));
    }

    public async Task<AppResult<PrivateMessageResponse>> SendPrivateMessageAsync(int currentUserId, int otherUserId,string text)
    {
        var dto=new SendMessageDto(currentUserId, otherUserId, text);
        
        return await _mediator.Send(SendMessageCommand.FromDto(dto));
    }

    public async Task<AppResult<EmptyResult>> UpdateUnreadMessagesAsync(IEnumerable<int> messageIdList)
    {
        return await _mediator.Send(new UpdateUnreadMessagesRequest(messageIdList));
    }
}