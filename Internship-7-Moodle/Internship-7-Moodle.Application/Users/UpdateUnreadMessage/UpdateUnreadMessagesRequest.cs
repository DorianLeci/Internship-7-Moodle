using Internship_7_Moodle.Application.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Users.UpdateUnreadMessage;

public class EmptyResult { }

public record UpdateUnreadMessagesRequest(IEnumerable<int> MessageIdList) 
    : IRequest<AppResult<EmptyResult>>;