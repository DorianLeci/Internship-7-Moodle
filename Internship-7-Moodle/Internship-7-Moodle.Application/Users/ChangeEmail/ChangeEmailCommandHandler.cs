using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;
using ValidationResult = Internship_7_Moodle.Domain.Common.Validation.ValidationResult;

namespace Internship_7_Moodle.Application.Users.ChangeEmail;

public class ChangeEmailCommandHandler:IRequestHandler<ChangeEmailCommand,AppResult<ChangeEmailResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;
    private readonly UserDomainService _userDomainService;

    public ChangeEmailCommandHandler(IUserUnitOfWork userUnitOfWork, UserDomainService userDomainService)
    {
        _userUnitOfWork = userUnitOfWork;
        _userDomainService = userDomainService;
    }
    
    public async Task<AppResult<ChangeEmailResponse>> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        var result = new AppResult<ChangeEmailResponse>();

        var validationResult = new ValidationResult();
        
        var userToChange = await _userUnitOfWork.UserRepository.GetByIdAsync(request.UserId,u=>u.Role);
        
        if (userToChange == null)
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(User), "Korisnik"));
            result.SetValidationResult(validationResult);
            return result;
        }
        
        if (!await _userDomainService.IsEmailUnique(request.NewEmail))
        {
            validationResult.Add(EntityValidation.UserValidation.EmailNotUnique);
            result.SetValidationResult(validationResult);
            return result;
        }
        
        var oldEmail=userToChange.Email;
        userToChange.Email = request.NewEmail;
        
        _userUnitOfWork.UserRepository.Update(userToChange);

        await _userUnitOfWork.SaveAsync();

        result.SetResult(new ChangeEmailResponse
        {
            Id=userToChange.Id,
            OldEmail = oldEmail!,
            NewEmail =  request.NewEmail,
        });

        return result;
    }
}