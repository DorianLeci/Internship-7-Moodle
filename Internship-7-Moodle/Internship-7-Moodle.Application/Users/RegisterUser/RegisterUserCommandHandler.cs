using System.ComponentModel.DataAnnotations;
using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Domain.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ValidationResult = Internship_7_Moodle.Domain.Common.Validation.ValidationResult;

namespace Internship_7_Moodle.Application.Users.RegisterUser;

public class RegisterUserCommandHandler:IRequestHandler<RegisterUserCommand,AppResult<SuccessPostResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly UserDomainService  _userDomainService;
    
    public RegisterUserCommandHandler(IUserUnitOfWork userUnitOfWork, IPasswordHasher<User> passwordHasher,UserDomainService userDomainService)
    {
        _userUnitOfWork = userUnitOfWork;
        _passwordHasher = passwordHasher;
        _userDomainService = userDomainService;
    }

    public async Task<AppResult<SuccessPostResponse>> Handle(RegisterUserCommand request,CancellationToken cancellationToken)
    {
        var result=new AppResult<SuccessPostResponse>();
        
        if (await _userDomainService.IsEmailUnique(request.Email))
        {
            var emailValidationResult = new ValidationResult();
            emailValidationResult.Add(EntityValidation.UserValidation.EmailNotUnique);
            result.SetValidationResult(emailValidationResult);
            
            return result;
        }
        
        var role=await _userUnitOfWork.RoleRepository.GetByRoleEnumAsync(request.RoleName);
        if (role == null)
        {
            var roleExistsValidationResult = new ValidationResult();
            roleExistsValidationResult.Add(EntityValidation.RoleValidation.RoleMustExist);
            result.SetValidationResult(roleExistsValidationResult);
            
            return result;
        }
        
        var newUser = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            Email = request.Email,
            Password = request.Password,
            Gender = request.Gender,
            Role = role
        };

        var domainResult= await newUser.Create(_userUnitOfWork.UserRepository);
        result.SetValidationResult(domainResult.ValidationResult!);
        
        if (result.IsFailure)
            return result;

        await _userUnitOfWork.SaveAsync();
        
        result.SetSuccessResult(new SuccessPostResponse(domainResult.Value));
        return result;
    }
    
}