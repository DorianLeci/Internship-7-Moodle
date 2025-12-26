using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Users;

namespace Internship_7_Moodle.Domain.Services;

public class UserDomainService
{
    private readonly IUserRepository _userRepository;

    public UserDomainService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> IsEmailUnique(string email, int? excludeId = null)
    {
        var exists = await _userRepository.ExistsByEmailAsync(email, excludeId);
        return !exists;
    }


}
