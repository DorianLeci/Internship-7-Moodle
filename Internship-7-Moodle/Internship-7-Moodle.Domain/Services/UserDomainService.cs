using Internship_7_Moodle.Domain.Persistence.Users;

namespace Internship_7_Moodle.Domain.Services;

public class UserDomainService
{
    private readonly IUserUnitOfWork _userUnitOfWork;

    public UserDomainService(IUserUnitOfWork userUnitOfWork)
    {
        _userUnitOfWork = userUnitOfWork;
    }

    public async Task<bool> IsEmailUnique(string email, int? excludeId = null)
    {
        var exists = await _userUnitOfWork.UserRepository.ExistsByEmailAsync(email, excludeId);
        return !exists;
    }

    public bool IsEmailSame(string oldEmail, string newEmail)
    {
        return string.Equals(oldEmail, newEmail);
    }




}
