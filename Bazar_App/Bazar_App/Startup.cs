using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Bazar_App.Data;
using Bazar_App.Models.Interface;
using Bazar_App.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Bazar_App.Auth.Models;
using Microsoft.AspNetCore.Http;
using Bazar_App.Auth.Interfaces;
using Bazar_App.Auth.Services;

namespace Bazar_App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<BazaarDBContext>(options => {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<BazaarDBContext>();

            // Invalid user redirects
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Auth/index";
            });

            // Alternative to JWT, use the built-in authentication system
            services.AddAuthentication();
            services.AddAuthorization();

            services.AddTransient<IProduct, ProductServices>();
            services.AddTransient<ICategory, CategoryServiece>();
            services.AddTransient<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}