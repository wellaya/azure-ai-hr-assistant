using EmployeeService.Application.Interfaces;
using EmployeeService.Infrastructure.Repositories;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services
    .AddScoped<IEmployeeService, EmployeeService.Application.Services.EmployeeService>()
    .AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();

builder.Build().Run();
