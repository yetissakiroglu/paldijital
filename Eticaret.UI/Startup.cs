using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.Core.DependencyResolvers;
using Eticaret.Core.Entities.Concrete;
using Eticaret.Core.Extensions;
using Eticaret.Core.Utilities.IoC;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Eticaret.UI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(_configuration["ConnectionStrings:IdentityConnection"], b => b.MigrationsAssembly("Eticaret.UI"));
            });
            services.AddAutoMapper(typeof(Startup));


            //Yönetim Paneli Ýçin Role için Claims
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("Administrator", policy =>
                {
                    policy.RequireClaim("administrator");
                });
                opts.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim("admin");
                });
                opts.AddPolicy("Editor", policy =>
                {
                    policy.RequireClaim("editor");
                });
                opts.AddPolicy("Delete", policy =>
                {
                    policy.RequireClaim("delete");
                });
                opts.AddPolicy("Create", policy =>
                {
                    policy.RequireClaim("create");
                });
                opts.AddPolicy("Edit", policy =>
                {
                    policy.RequireClaim("edit");
                });
                opts.AddPolicy("List", policy =>
                {
                    policy.RequireClaim("List");
                });
                opts.AddPolicy("List", policy =>
                {
                    policy.RequireClaim("View");
                });
            });

            services.AddControllersWithViews();


            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // password
                //Þifre Uzunluðu
                options.Password.RequiredLength = 6;
                //Alpha Numaric Karakter *,. gibi girilmesin
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;


                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //Kullanýcý karakter Kullanýmý
                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/ysadmin/account/login";
                options.LogoutPath = "/ysadmin/account/logout";
                options.AccessDeniedPath = "/ysadmin/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Web.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });

            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });


            services.AddDependencyResolvers(new ICoreModule[]
           {
                new CoreModule(),
           });
            services.AddRazorPages().AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // app.ConfigureCustomExceptionMiddleware();

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStatusCodePages();
            app.UseAuthentication();
            //app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                name: "NewsDetail",
                template: "haberler/{categoryUrl}/{newsUrl}",
                defaults: new { controller = "News", action = "Detail" });

                routes.MapRoute(
                name: "NewsCategory",
                template: "haberler/{categoryUrl}",
                defaults: new { controller = "News", action = "Category" });

                routes.MapRoute(name: "News",
                template: "haberler",
                defaults: new { controller = "News", action = "Index" });

                routes.MapRoute(name: "Radio",
                template: "radyolar",
                defaults: new { controller = "Radio", action = "Index" });

                routes.MapRoute(name: "Frequency",
                template: "frekanslar",
                defaults: new { controller = "Frequency", action = "Index" });

                routes.MapRoute(
                name: "podcastDetail",
                template: "podcast/{podcastUrl}",
                defaults: new { controller = "Podcast", action = "Detail" });

                routes.MapRoute(name: "Podcast",
                template: "podcast",
                defaults: new { controller = "Podcast", action = "Index" });

                routes.MapRoute(name: "Bildir",
                template: "bildir",
                defaults: new { controller = "bildir", action = "Index" });

                routes.MapRoute(name: "Contact",
                template: "iletisim",
                defaults: new { controller = "contact", action = "Index" });

                routes.MapRoute(name: "Events",
                template: "etkinlikler",
                defaults: new { controller = "Events", action = "Index" });

                routes.MapRoute(name: "List",
                template: "listeler",
                defaults: new { controller = "List", action = "Index" });

                routes.MapRoute(name: "Musicarchive",
               template: "muzik-listeleri",
               defaults: new { controller = "Musicarchive", action = "Index" });

                routes.MapRoute(name: "Streaming",
                template: "yayin-akisi",
                defaults: new { controller = "Streaming", action = "Index" });

                routes.MapRoute(name: "Program",
                template: "programlar",
                defaults: new { controller = "Program", action = "Index" });

            });


        }
    }
}
