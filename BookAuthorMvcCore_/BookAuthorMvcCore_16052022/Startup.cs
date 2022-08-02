using BookAuthorMvcCore_16052022.Infrastructure.Context;
using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Concrete;
using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.EntityRepo;
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

namespace BookAuthorMvcCore_16052022
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

            services.AddDbContext<ProjectContext>(options=> 
            { 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies(true);

            });
            // addScoped gömülü(built-in-function)lardan bir tanesidir. Uygulamada Her IAuthorRepository çağırdığımız yer için bize bir AuthorRepository nesnesi gönderir yapacağımız/kullanacağımız metotların açıklmasını bilen onların interface hali değil concrete halidir. Bu yüzden AuthorRepository ihtiyacımız vardır.

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IDetailRepository, DetailRepository>();

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
