using Microsoft.Extensions.Hosting;
using Internship_7_Moodle.Application.Dependencies;
using Internship_7_Moodle.Infrastructure.Database;
using Internship_7_Moodle.Infrastructure.Dependencies;
using Internship_7_Moodle.Presentation.Actions;
using Internship_7_Moodle.Presentation.MenuDependencies;
using Internship_7_Moodle.Presentation.Service;
using Internship_7_Moodle.Presentation.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder=Host.CreateApplicationBuilder();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAppServices(builder.Configuration);

builder.Logging.ClearProviders();


builder.Services.AddScoped<UserActions>();
builder.Services.AddScoped<CourseActions>();
builder.Services.AddScoped<ChatActions>();

builder.Services.AddScoped<MenuDependencies>(sp => new MenuDependencies
{
    UserActions = sp.GetRequiredService<UserActions>(),
    CourseActions = sp.GetRequiredService<CourseActions>(),
    ChatActions = sp.GetRequiredService<ChatActions>()
});

builder.Services.AddScoped<MenuManager>();
builder.Services.AddScoped<AntiBotService>();
    
var host=builder.Build();

var scope = host.Services.CreateScope();

var dbContext=scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
dbContext.Database.Migrate();

var menuManager = scope.ServiceProvider.GetRequiredService<MenuManager>();
await menuManager.RunAsync();