using Internship_7_Moodle.Domain.Common.Helper;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;
using Internship_7_Moodle.Domain.Persistence.Common;

namespace Internship_7_Moodle.Domain.Persistence.Users;

public interface IUserRepository:IRepository<User,int>
{
    Task<bool> ExistsByEmailAsync(string email,int ?excludeId=null);
    
    Task<User?> GetUserByEmailAsync(string email);
    
    Task<IEnumerable<Course>> GetAllStudentCoursesAsync(int studentId);
    
    Task<IEnumerable<Course>> GetAllProfessorCoursesAsync(int professorId);
    
    Task<IEnumerable<User>> GetAllStudentsAsync();

    Task<IEnumerable<(RoleEnum Role, int Count)>> GetUserCountGroupedByRole(PeriodEnum period);




}