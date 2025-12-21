using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Users;

public interface IUserRepository:IRepository<User,int>
{
    Task<bool> ExistsByEmailAsync(string email,int ?excludeId=null);
    
}