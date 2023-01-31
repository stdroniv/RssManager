using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RssApi.BLL.Contracts;
using RssApi.BLL.Services;
using RssApi.Configuration;
using RssApi.DAL;
using RssApi.DAL.Configuration;
using RssApi.DAL.Entities;

namespace RssApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlite(configuration.GetConnectionString("RssApiDatabase")));
    
    public static void AddIdentity(this IServiceCollection services) => 
        services.AddIdentity<User,IdentityRole>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
    }

    public static void ConfigureJwt(this IServiceCollection services, JwtSettings jwtSettings)
    {
        var secretKey = "mysupersecretkey";

        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
    }
}

