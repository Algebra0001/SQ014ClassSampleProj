using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCSQ014_RazorViews.Data;
using System.Runtime.CompilerServices;

namespace MVCSQ014_RazorViews.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddIdentity(IServiceCollection services)
        {
           services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MVCContext>()
            .AddDefaultTokenProviders();
        }

        public static void AddAuth(IServiceCollection services)
        {
            services.AddAuthorization(config =>
            {
                config.AddPolicy("AdminPolicy", policy => policy.RequireRole("admin"));
            });
        }

        public static void AddDbContext(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<MVCContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Default"))
            );
        }
    }
}
