using CitizenArcadis.Client.UI.DataAccess;
using CitizenArcadis.Client.UI.Models.DataContext;
using CitizenArcadis.Client.UI.Models.DTO;
using CitizenArcadis.Client.UI.Service;
using CitizenArcadis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;

namespace CitizenArcadis.Client.UI
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContextPool<CitizenArcadisDBContext>(options =>
            options.UseSqlServer(this.Configuration.GetConnectionString("CitizenArcadisDBConnection")));
            services.AddSingleton<IAzureDemoFunction, AzureDemoFunction>();
            services.AddScoped<IBaseDBContext<EmployeeDTO>, EmployeeAccess>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
