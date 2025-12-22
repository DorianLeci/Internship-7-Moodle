using Internship_7_Moodle.Application.Users.RegisterUser;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Internship_7_Moodle.Application.Dependencies;

public static class DependencyInjection
{
    public static void AddAppServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddMediatR(typeof(RegisterUserCommandHandler).Assembly);
        services.AddScoped<UserDomainService>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    }
}