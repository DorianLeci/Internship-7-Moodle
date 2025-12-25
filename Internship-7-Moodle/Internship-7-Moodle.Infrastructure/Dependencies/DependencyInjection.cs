using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Persistence.Roles;
using Internship_7_Moodle.Domain.Persistence.Users;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Internship_7_Moodle.Infrastructure.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepository();
        services.AddDatabase(configuration);
        return services;
    }

    private static void AddRepository(this IServiceCollection services)
    {
        
        services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository,RoleRepository>();
    }

    
    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var userDbConnectionString = configuration.GetConnectionString("MoodleDB");
        if (string.IsNullOrEmpty(userDbConnectionString))
            throw new ArgumentNullException(nameof(userDbConnectionString));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(userDbConnectionString)
                .LogTo(_ => { }, Array.Empty<string>(), Microsoft.Extensions.Logging.LogLevel.None));

    }    
}