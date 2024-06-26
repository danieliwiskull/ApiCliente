using AutoMapper;
using WebApp.Configurations;
using ClassLibraryRepositories.Contracts;
using ClassLibraryRepositories.Implementations;
using ClassLibraryServices.Contracts;
using ClassLibraryServices.Implementations;
using ClassLibraryUtilities.Contracts;
using Microsoft.OpenApi.Models;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            // Mapper Config
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);

            // Add settings
            services.AddSingleton<IMConfiguration, MConfiguration>();

            // Add singletones
            //services.AddSingleton<ILogRepository, LogRepository>();

            // Add services
            services.AddScoped<IClienteService, ClienteService>();

            // Add repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddControllers();

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Cliente", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Cliente V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}