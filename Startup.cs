//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.DependencyInjection;
//using SportsStore.Models;
//using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore;

//namespace SportsStore
//{
//    public class Startup
//    {

//        public Startup(IConfiguration configuration) =>
//            Configuration = configuration;
//        public IConfiguration Configuration
//        {
//            get;
//        }


//        // This method gets called by the runtime. Use this method to add services to the container.
//        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
//        public void ConfigureServices(IServiceCollection services)
//        {
//            //    The ConfigureServices method is used to set up shared objects that 
//            //    can be used throughout the application through the dependency injection feature
//            services.AddDbContext<ApplicationDbContext>(options => 
//            options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
//            services.AddTransient<IProductRepository, EFProductRepository>();
//           // services.AddTransient<IProductRepository, FakeProductRepository>();
//            services.AddMvc();


//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            app.UseDeveloperExceptionPage(); //This extension method displays details of exceptions that occur in the application, which is useful during the development process. It should not be enabled in deployed application
//            app.UseStatusCodePages(); //This extension method adds a simple message to HTTP responses that would not otherwise have a body, such as 404 - Not Found responses.
//            app.UseStaticFiles(); //This extension method enables support for serving static content from the wwwroot folder.
//            app.UseMvc(routes => { //This extension method enables ASP.NET Core MVC.
//            });

//            app.UseMvc(routes => {
//                routes.MapRoute(name: "default", 
//                    template: "{controller=Product}/{action=List}/{id?}");
//            });

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.Run(async (context) =>
//            {
//                await context.Response.WriteAsync("Hello World!");
//            });
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
        //    services.AddDbContext<ApplicationDbContext>(options => 
        //    options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
        services.AddDbContext<ApplicationDbContext>(options =>   
            options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage(); app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}