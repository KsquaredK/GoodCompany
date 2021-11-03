using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GoodCompanyMVC.Auth;
using GoodCompanyMVC.Repositories;

namespace GoodCompanyMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<IFirebaseAuthService, FirebaseAuthService>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IPositionLevelRepository, PositionLevelRepository>();
            services.AddTransient<IApplicationNoteRepository, ApplicationNoteRepository>();


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.Cookie.SameSite = SameSiteMode.Strict);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
//not included in scaffolding; added to render "Not Found"
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

//defines pattern: which controller action to invoke, based on URL route
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Application}/{action=Index}/{id?}");
            });
        }
    }
}
