using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Conventions;
using Microsoft.OpenApi.Models;

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
            services.AddControllers();
            services.AddApiVersioning(
                        options =>
                        {
                            options.DefaultApiVersion = new ApiVersion(1.0);
                            options.AssumeDefaultVersionWhenUnspecified = true;
                            // reporting api versions will return the headers
                            // "api-supported-versions" and "api-deprecated-versions"
                            options.ReportApiVersions = true;
                            options.ApiVersionReader = ApiVersionReader.Combine(
                                   new UrlSegmentApiVersionReader(),
                                   new QueryStringApiVersionReader("api-version"),
                                   new HeaderApiVersionReader("X-Version"),
                                   new MediaTypeApiVersionReader("x-version"));
                        })
                    .AddMvc(
                        options =>
                        {
                            // automatically applies an api version based on the name of
                            // the defining controller's namespace
                            options.Conventions.Add(new VersionByNamespaceConvention());
                        })
                    .AddApiExplorer(setup =>
                        {
                            setup.GroupNameFormat = "'v'VVV";
                            setup.SubstituteApiVersionInUrl = true;
                        });


            services.AddSwaggerGen();
            services.ConfigureOptions<NamedSwaggerGenOptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant()); 
                } 
            });
        }
    }
}
