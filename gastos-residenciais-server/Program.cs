using Domain.Entities;
using Domain.Repositories;
using gastos_residenciais_server.Middleware;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Extensions;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using System.Text.Json.Serialization;

TypeAdapterConfig.GlobalSettings.Scan(typeof(Persistence.AssemblyReference).Assembly);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddDbContextPool<ExpensesManagementDatabaseContext>(b =>
{
    var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionString");

    if (connectionString is null)
    {
        throw new InvalidOperationException("Connection string 'DatabaseConnectionString' not found.");
    }

    b.UseMySQL(connectionString).LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    })
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Logging.AddConsole();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
