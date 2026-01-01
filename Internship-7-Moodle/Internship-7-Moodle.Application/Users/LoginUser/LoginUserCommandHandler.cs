using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Internship_7_Moodle.Application.Users.LoginUser;

public class LoginUserCommandHandler:IRequestHandler<LoginUserCommand,AppResult<UserLoginResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginUserCommandHandler(IUserUnitOfWork userUnitOfWork, IPasswordHasher<User> passwordHasher)
    {
        _userUnitOfWork = userUnitOfWork;
        _passwordHasher = passwordHasher;
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
        
        result.SetResult(new UserLoginResponse
            {
                Id=user.Id, 
                RoleName = user.Role.RoleName,
                FirstName = user.FirstName!,
                LastName = user.LastName!,
            }
            );
        
        return result;

    }
}