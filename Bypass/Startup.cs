using Bypass.Data.Interfaces;
using Bypass.Data.Mocks;
using Bypass.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bypass
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            addTransient(services, true);

            

            services.AddAuthentication("MyAuthCookie").AddCookie("MyAuthCookie", options => {
                options.Cookie.Name = "MyAuthCookie";
                options.LoginPath = "/user/login";
            });
        }

        private void addTransient(IServiceCollection services, bool mock = false)
        {
            if (mock)
            {
                services.AddTransient<IBypassItems, MockBypass>();
                services.AddTransient<IArchiveModel, MockArchive>();
                services.AddTransient<IEditModel, MockEdit>();
                return;
            }
            services.AddTransient<IBypassItems, BypassModel>();
            services.AddTransient<IArchiveModel, ArchiveModel>();
            services.AddTransient<IEditModel, EditModel>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
