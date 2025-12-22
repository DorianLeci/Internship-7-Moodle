using Microsoft.Extensions.Hosting;
using Internship_7_Moodle.Application.Dependencies;

var builder=Host.CreateApplicationBuilder();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAppServices(builder.Configuration);
