using Domain.Entities;
using gastos_residenciais_server.Middleware;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Persistence;
using Persistence.Extensions;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddScoped<IServiceManager, ServiceManager>();
// builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<Users>()
    .AddEntityFrameworkStores<GerenciamentoDeGastosDatabaseContext>()
    .AddApiEndpoints();

builder.Services.AddDbContextPool<GerenciamentoDeGastosDatabaseContext>(b =>
{
    var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionString");

    if (connectionString is null)
    {
        throw new InvalidOperationException("Connection string 'DatabaseConnectionString' not found.");
    }

    b.UseMySQL(connectionString).LogTo(Console.WriteLine, LogLevel.Information);
});

//builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
//{
//    options.User.RequireUniqueEmail = true;
//});

builder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
})
.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Logging.AddConsole();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapIdentityApi<Users>();
app.MapControllers();

app.Run();
