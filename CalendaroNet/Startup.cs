using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalendaroNet.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CalendaroNet.Services;
using MySql.Data;
using CalendaroNet.Services.Employees;
using CalendaroNet.Services.TodoItems;
using CalendaroNet.Services.Services;
using CalendaroNet.Services.Schedules;

namespace CalendaroNet
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Use SQL Database if in Azure, otherwise, use SQLite
            // if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            // services.AddDbContext<ApplicationDbContext>(options =>
            //             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection1")));
            // else
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("LocalConnection")));//Zmienić DefaultConnection1 i useSQLServer podczas wdrożania na SQL
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection1")));//Zmienić DefaultConnection1 i useSQLServer podczas wdrożania na SQL

            // Automatically perform database migration
            //services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI() 
            .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<ITodoItemsService, TodoItemsService>();
            services.AddScoped<ISchedulesService, SchedulesService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IServiceService, ServiceService>();

            services.AddAuthentication();
            //Add app services
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}