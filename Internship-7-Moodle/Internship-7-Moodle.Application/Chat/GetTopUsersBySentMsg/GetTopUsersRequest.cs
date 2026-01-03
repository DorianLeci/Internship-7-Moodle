using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.Chat;
using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Common.Model;
using MediatR;

namespace Internship_7_Moodle.Application.Chat.GetTopUsersBySentMsg;

public record GetTopUsersRequest(PeriodEnum Period):IRequest<AppResult<GetAllResponse<TopUsersByMsgResponse>>>
{
    
}