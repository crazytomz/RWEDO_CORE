using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RWEDO.DataTransferObject;
using StructureMap;

namespace RWEDO
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<RWEDODbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("DBConnection")));
            services.AddMvc();
            services.AddAuthentication("CookieAuthentication")
                    .AddCookie("CookieAuthentication", options =>
                    {
                        options.AccessDeniedPath = new PathString("/Account/Forbidden/");
                        options.LoginPath = new PathString("/Account/Index");
                    });
            // services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<ISurveyorRepository, SurveyorRepository>();
            var container = new Container(scope =>
            {                
                scope.Scan(x =>
                {
                    x.Assembly("RWEDO.MSQLRepository");
                    x.WithDefaultConventions();

                });
            });
            container.Populate(services);
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Account}/{action=Login}");
            });
        }
    }
}
