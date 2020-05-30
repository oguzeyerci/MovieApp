using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using filmapp.business.Abstract;
using filmapp.business.Concrete;
using filmapp.data.Abstract;
using filmapp.data.Concrete.EfCore;
using filmapp.webui.EmailServices;
using filmapp.webui.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace filmapp.webui
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration=configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options=>options.UseSqlite("Data Source=movieDb"));
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options=>{
                //password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength=6;
                options.Password.RequireNonAlphanumeric=false;
                options.Password.RequireUppercase=false;
                //Lockout
                options.Lockout.MaxFailedAccessAttempts=5;//5 yanlış giriş hakkı
                options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromDays(1); //kilitli kalma süresi
                options.Lockout.AllowedForNewUsers=true;

                //options.User.AllowedUserNameCharacters="";
                options.User.RequireUniqueEmail= true;
                options.SignIn.RequireConfirmedEmail=true;
                //options.SignIn.RequireConfirmedPhoneNumber = true;

            });
            //cookie ayarları
            services.ConfigureApplicationCookie(options=>{
                options.LoginPath="/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath ="/Account/AccessDenied";
                options.SlidingExpiration=true; //cookie süresi tazeleme
                options.ExpireTimeSpan=TimeSpan.FromMinutes(60); //cookie süresi
                options.Cookie= new CookieBuilder
                {
                    HttpOnly=true,
                    Name=".MovieApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });
            services.AddScoped<IMovie,EfCoreMovieRepo>();
            services.AddScoped<IMovieService,MovieManager>();
            services.AddControllersWithViews();
            services.AddScoped<IEmailSender,GmailEmailSender>(i=>
            new GmailEmailSender(
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                _configuration["EmailSender:UserName"],
                _configuration["EmailSender:Password"])
            );
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseStaticFiles(); //wwwroot
            app.UseStaticFiles(new StaticFileOptions{
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),RequestPath="/modules"
            });

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
                
            });
        }
    }
}
