using System.ComponentModel.DataAnnotations;
using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation.Users;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ValidationResult = Internship_7_Moodle.Domain.Common.Validation.ValidationResult;

namespace Internship_7_Moodle.Application.Users.RegisterUser;

public class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommand,Result<SuccessPostResponse>>
{
    private readonly IUserUnitOfWork userUnitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly UserDomainService  _userDomainService;
    
    public RegisterUserCommandHandler(IUserUnitOfWork userUnitOfWork, IPasswordHasher<User> passwordHasher,UserDomainService userDomainService)
    {
        this.userUnitOfWork = userUnitOfWork;
        _passwordHasher = passwordHasher;
        _userDomainService = userDomainService;
    }

    public async Task<Result<SuccessPostResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userDomainService.IsEmailUnique(request.Email))
        {
            var emailValidationResult = new ValidationResult();
            emailValidationResult.Add(EntityValidation.UserValidation.EmailNotUnique);
            return Result<SuccessPostResponse>.Failure(emailValidationResult);
        }
        
        var role=await userUnitOfWork.RoleRepository.GetByRoleEnumAsync(request.RoleName);

        var newUser = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            Email = request.Email,
            Password = request.Password,
            Gender = request.Gender,
            Role = role;
        };

        var result= newUser.Create();

        if (result.ValidationResult!.HasErrors)
            return result;
    }
}