using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Skyrmium.Api.Implementations.Errors;
using Skyrmium.Api.Implementations.Middlewares;
using Skyrmium.Equivalent.Measurement.Startup;

namespace Skyrmium.Equivalent.Measurement.Api
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
         services.AddControllers(o => o.Filters.Add<ExceptionFilter>());
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skyrmium.Equivalent.Measurement.Api", Version = "v1" });
         });

         Initialization.RegisterAll(new Container(services), new Configuration(this.Configuration), new IocBulkRegistrarMeasurementApi());
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage()
               .UseSwagger()
               .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skyrmium.Equivalent.Measurement.Api v1"));
         }

         app.UseFinishUnitOfWorkMiddleware()
            .UseLocalizationMiddleware()
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();
            });
      }
   }
}
