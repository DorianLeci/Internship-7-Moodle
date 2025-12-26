using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Users.Response;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Internship_7_Moodle.Application.Users.LoginUser;

public class LoginUserCommandHandler:IRequestHandler<LoginUserCommand,AppResult<UserLoginResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly UserDomainService  _userDomainService;

    public LoginUserCommandHandler(IUserUnitOfWork userUnitOfWork, IPasswordHasher<User> passwordHasher,UserDomainService userDomainService)
    {
        _userUnitOfWork = userUnitOfWork;
        _passwordHasher = passwordHasher;
        _userDomainService = userDomainService;
    }
    
    public async Task<AppResult<UserLoginResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result=new AppResult<UserLoginResponse>();
        var validationResult = new ValidationResult();
        
        var user=await _userUnitOfWork.UserRepository.GetUserByEmailAsync(request.Email);

        if (user == null)
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(User),"Email korisnika"));
            result.SetValidationResult(validationResult);
            return result;
        }
        
        var passwordValid=_passwordHasher.VerifyHashedPassword(user,user.Password,request.Password);

        if (passwordValid == PasswordVerificationResult.Failed)
        {
            validationResult.Add(EntityValidation.UserValidation.InvalidPassword);
            result.SetValidationResult(validationResult);
            return result;
        }
        
        result.SetSuccessResult(new UserLoginResponse(user.Id,user.Role.RoleName));
        return result;

    }
}