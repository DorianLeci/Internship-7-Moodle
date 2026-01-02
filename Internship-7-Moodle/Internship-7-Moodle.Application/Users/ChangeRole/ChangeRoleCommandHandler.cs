using Internship_7_Moodle.Application.Common.Model;
using Internship_7_Moodle.Application.Response.User;
using Internship_7_Moodle.Domain.Common.Validation;
using Internship_7_Moodle.Domain.Common.Validation.EntityValidation;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Users;
using MediatR;

namespace Internship_7_Moodle.Application.Users.ChangeRole;

public class ChangeRoleCommandHandler:IRequestHandler<ChangeRoleCommand,AppResult<ChangeRoleResponse>>
{
    private readonly IUserUnitOfWork _userUnitOfWork;

    public ChangeRoleCommandHandler(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }
    
    public async Task<AppResult<ChangeRoleResponse>> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        var result=new AppResult<ChangeRoleResponse>();

        var validationResult = new ValidationResult();
        
        var userToChange = await _userUnitOfWork.UserRepository.GetByIdAsync(request.UserId,u=>u.Role);
        
        if (userToChange == null)
        {
            validationResult.Add(EntityValidation.CommonValidation.ItemMustExist(nameof(User), "Korisnik"));
            result.SetValidationResult(validationResult);
            return result;
        }
        
        if (userToChange.Role.RoleName == RoleEnum.Professor)
        {
            var profCourses=await _userUnitOfWork.UserRepository.GetAllProfessorCoursesAsync(request.UserId);
            
            if (profCourses.Any())
            {
                validationResult.Add(EntityValidation.UserValidation.ProfessorRoleChangeError);
                result.SetValidationResult(validationResult);
                return result;
            }
        }    
        
        var oldRole = userToChange.Role.RoleName;
        var newRole=(oldRole==RoleEnum.Professor) ? RoleEnum.Student : RoleEnum.Professor;
        
        userToChange.RoleId=(int)newRole+1;
        
        _userUnitOfWork.UserRepository.Update(userToChange);

        await _userUnitOfWork.SaveAsync();

        result.SetResult(new ChangeRoleResponse
        {
            Id=userToChange.Id,
            OldRoleName = oldRole,
            NewRoleName = newRole
        });

        return result;
    }
}