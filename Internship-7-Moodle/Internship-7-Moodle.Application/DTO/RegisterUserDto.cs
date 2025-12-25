using Internship_7_Moodle.Domain.Enumerations;

namespace Internship_7_Moodle.Application.DTO;

public record RegisterUserDto(string FirstName,string LastName,DateOnly BirthDate,string Email,GenderEnum? Gender,string Password, RoleEnum RoleName)
{}