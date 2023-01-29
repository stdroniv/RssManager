using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RssApi.DAL;
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
            .AddEntityFrameworkStores<AppDbContext>();
}

