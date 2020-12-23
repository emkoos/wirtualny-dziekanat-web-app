using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WirtualnyDziekanat.Application.Services;
using WirtualnyDziekanat.Domain.Repositories;
using WirtualnyDziekanat.Infrastructure.Data;
using WirtualnyDziekanat.Infrastructure.Mappers;
using WirtualnyDziekanat.Infrastructure.Repositories;
using WirtualnyDziekanat.Infrastructure.Services;
using Newtonsoft.Json;

namespace WirtualnyDziekanat.WebUI
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
            services.AddDbContext<AppDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("AppDbConnectionString"),
                    optionsbuilder => optionsbuilder.MigrationsAssembly("WirtualnyDziekanat.WebUI"));

            });
            
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllersWithViews()
                .AddNewtonsoftJson(x => x.SerializerSettings.Formatting = Formatting.Indented);


            services.AddScoped<IInformationRepository, InformationRepository>();
            services.AddScoped<IInformationService, InformationService>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddSingleton(AutoMapperConfig.Initialize());

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
