using ApiVersioningDemoInNet7.Controllers;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning.Conventions;



namespace ApiVersioningDemoInNet7
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
            // Add persistence
            // Add services to the container.
            services.AddControllers();

            services.AddApiVersioning(
                    options =>
                    {
                        // reporting api versions will return the headers
                        // "api-supported-versions" and "api-deprecated-versions"
                        options.ReportApiVersions = true;

                    })
                .AddMvc(
                    options =>
                    {
                        options.Conventions.Controller<TestController>()
                                           .HasApiVersion(1.0)
                                           .HasApiVersion(2.0)
                                           .Action(c => c.TestMethod()).MapToApiVersion(1.0)
                                           .Action(c => c.TestMethodV2()).MapToApiVersion(2.0);
       
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
 
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
