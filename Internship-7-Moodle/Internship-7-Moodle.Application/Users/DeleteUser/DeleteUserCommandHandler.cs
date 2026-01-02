using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;
using ValidationResult = Internship_7_Moodle.Domain.Common.Validation.ValidationResult;

namespace Internship_7_Moodle.Application.Users.DeleteUser;

public class DeleteUserCommandHandler:IRequestHandler<DeleteUserCommand,AppResult<SuccessResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;

    public DeleteUserCommandHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    
    public async Task<AppResult<SuccessResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result=new AppResult<SuccessResponse>();

        var validationResult = new ValidationResult();
        
        var userToDelete = await _userUnitOfWork.UserRepository.GetByIdAsync(request.UserId);

        if (userToDelete == null)
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(User), "Korisnik"));
            result.SetValidationResult(validationResult);
            return result;
        }
        
        _userUnitOfWork.UserRepository.Delete(userToDelete);

        await _userUnitOfWork.SaveAsync();
        
        result.SetResult(new SuccessResponse("Korisnik uspješno obrisan"));

        return result;
    }
}