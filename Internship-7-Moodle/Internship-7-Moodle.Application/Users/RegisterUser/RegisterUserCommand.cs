using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.DTO;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Enumerations;
using MediatR;

namespace Internship_7_Moodle.Application.Users.RegisterUser;

public record RegisterUserCommand(
    string FirstName,
    string LastName,
    DateOnly? BirthDate,
    string Email,
    string Password,
    GenderEnum? Gender,
    RoleEnum RoleName)
    : IRequest<AppResult<SuccessPostResponse>>
{
    public static RegisterUserCommand FromDto(RegisterUserDto dto)
    {
        return new RegisterUserCommand(dto.FirstName, dto.LastName, dto.BirthDate, dto.Email, dto.Password, dto.Gender,dto.RoleName);
    }
}    
