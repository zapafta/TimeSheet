using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace TimeSheet
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

            // Replace with your connection string.
            var connectionString = "server = localhost; port = 3306; database = timesheet; uid = root; password = root";

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();

            var builder = services.AddRazorPages();


#if DEBUG
            builder.AddRazorRuntimeCompilation();
#endif
            services.AddMvcCore();

            //services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.AddRazorRuntimeCompilation();
            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<ApplicationDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()       // <-- with debugging (remove for production).
            );
   
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/home";
            }
       ).AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = "243692003979059";
                facebookOptions.AppSecret = "53caeccb0c0567735af185b8059c417b";
            });


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<ClienteRepository>();
            services.AddTransient<ColaboradorRepository>();
            services.AddTransient<EventoRepository>();
            services.AddTransient<LocalizacaoRepository>();
            services.AddTransient<TipoServicoRepository>();


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




            app.UseRouting();

            app.UseAuthorization();



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDY3NDIxQDMxMzkyZTMyMmUzMG5ISWVDdS9SWWdCN1R4NXh2aGZhOGk4M1dzTk9zamRreGcrandYdFU4Wm89");

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpooints => endpooints.MapRazorPages()); 

        }

    }
}
