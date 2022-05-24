using Bumbo.Domain;
using Bumbo.Domain.Services.Credentials;
using Bumbo.Domain.Services.Forecasts;
using Bumbo.Domain.Services.Remunerations;
using Bumbo.Domain.Services.Schedules;
using Bumbo.Domain.Services.Employees;
using Bumbo.Domain.Services.Registrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bumbo.Domain.Services.CAO;
using Bumbo.Domain.Services.Dashboard;
using Bumbo.Domain.Services.Functions;
using Bumbo.Domain.Services.Departments;
using Bumbo.Domain.Services.Standards;
using Bumbo.Domain.Services.Branches;
using Bumbo.Domain.Services.OpeningDays;
using Bumbo.Domain.Services.Contracts;

namespace Bumbo.Web
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<BumboContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BumboConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                //Other options go here
            }).AddEntityFrameworkStores<BumboContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Credentials/AccessDenied");
                options.LoginPath = new PathString("/Credentials/Login");
                options.LogoutPath = new PathString("/Credentials/Logout");
            });

            services.AddScoped<ISchedule, ScheduleService>();
            services.AddScoped<IStandard, StandardService>();
            services.AddScoped<IRemuneration, RemunerationService>();
            services.AddScoped<ICredentials, CredentialsService>();
            services.AddScoped<IDashboard, DashboardService>();
            services.AddScoped<IForecast, ForecastService>();
            services.AddScoped<IEmployee, EmployeeService>();
            services.AddScoped<IRegistration, RegistrationService>();
            services.AddScoped<IFunction, FunctionService>();
            services.AddScoped<IDepartment, DepartmentService>();
            services.AddScoped<ICAO, CAOService>();
            services.AddScoped<IBranch, BranchService>();
            services.AddScoped<IOpeningDay, OpeningDayService>();
            services.AddScoped<IContract, ContractService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, BumboContext ctx)
        {
            ctx.Database.Migrate();

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

            app.UseRouting();
            app.UseAuthentication();

            UserAndRoleSeeder.SeedData(userManager, roleManager);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
