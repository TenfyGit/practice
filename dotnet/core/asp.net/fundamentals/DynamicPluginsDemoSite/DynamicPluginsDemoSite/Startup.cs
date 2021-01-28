using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DynamicPluginsDemoSite
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
            //services.AddControllersWithViews();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            var assembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory , "netcoreapp3.1", "DemoPlugin.dll"));
            var assemblyView = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "netcoreapp3.1", "DemoPlugin.Views.dll"));
            var viewAssemblyPart = new CompiledRazorAssemblyPart(assemblyView);

            var controllerAssemblyPart = new AssemblyPart(assembly);
            var mvcBuilders = services.AddMvc();

            mvcBuilders.ConfigureApplicationPartManager(apm =>
            {
                apm.ApplicationParts.Add(controllerAssemblyPart);
                apm.ApplicationParts.Add(viewAssemblyPart);
            });
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
