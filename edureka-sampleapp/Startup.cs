using edureka_sampleapp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp
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
            services.AddControllersWithViews();
            //services.AddScoped<IStoreRepository, AccountInMemoryRepository>();
            services.AddScoped<IStoreRepository, AccountDBRepository>();

            services.AddDbContext<EdurekaDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:BankAccountConnection"]);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
               
                endpoints.MapControllerRoute("catpage", "{category}/Page{accountpage:int:min(1)}",
                new { Controller = "Customer", action = "Index" });

                endpoints.MapControllerRoute("category", "{category}",
                new { Controller = "Customer", action = "Index", accountpage = 1 });
                endpoints.MapControllerRoute("pagination", "Accounts/Page{accountpage:int}",
                 new { Controller = "Customer", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Customer}/{action=Index}");
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
