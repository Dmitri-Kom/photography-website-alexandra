using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;
using API.Helpers;
using AutoMapper;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //it's going to be created when the HTTP request comes into our API,
            // creates a new instance of the controller. The controller sees that 
            // it needs a repository. So it creates the instance of the repository. 
            // And when the request is finished, then it disposes of both the controller 
            // and the repository.
            services.AddScoped<IPhotographRepository, PhotographRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            //Default lifetime is scoped, lifetime of the request;
            services.AddDbContext<PhotographsShopContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//displays the actual exception that has occured.                
            }
            //in the event that request comes into our API server, but we do 
            //not have an end point that matches that particular request, 
            //then we're going to hit this bit of middleware and it's going to 
            //redirect to our errors controller and pass in the status code and 
            //in our NotFoundEndpoint controller.
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
