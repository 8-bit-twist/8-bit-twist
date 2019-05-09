using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _8_Bit_Twist.Data;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Handlers;
using _8_Bit_Twist.Models.Interfaces;
using _8_Bit_Twist.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _8_Bit_Twist
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // Set up app to use User Secrets.
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Environment = environment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Toggle between Production and Dev depending on environment.
            string appConString, idConString;
            if (Environment.IsDevelopment())
            {
                appConString = Configuration.GetConnectionString("DefaultConnection");
                idConString = Configuration.GetConnectionString("DefaultIdConnection");
            }
            else
            {
                appConString = Configuration.GetConnectionString("ProductionConnection");
                idConString = Configuration.GetConnectionString("ProductionIdConnection");
            }

            // Add DB Context based on above toggle
            services.AddDbContext<_8BitDbContext>(options =>
                options.UseSqlServer(appConString));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(idConString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Uncomment below code to push updates ONLY to Local DB.
            //services.AddDbContext<_8BitDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultIdConnection")));

            // Uncomment below code to push updates ONLY to  Production DB.
            //services.AddDbContext<_8BitDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductionIdConnection")));

            // Register Interfaces and Services
            services.AddScoped<IInventoryManager, InventoryService>();
            services.AddScoped<IBasketManager, BasketService>();
            services.AddScoped<IOrderManager, OrderService>();
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ComputerPolicy", policy => policy.Requirements.Add(new ComputerRequirement()));
                options.AddPolicy("EmailPolicy", policy => policy.Requirements.Add(new EmailRequirement()));
            });

            services.AddTransient<IAuthorizationHandler, ComputerHandler>();
            services.AddScoped<IAuthorizationHandler, EmailHandler>();
            services.AddScoped<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
