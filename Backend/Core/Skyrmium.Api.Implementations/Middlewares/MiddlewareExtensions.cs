using Microsoft.AspNetCore.Builder;

namespace Skyrmium.Api.Implementations.Middlewares
{
   public static class MiddlewareExtensions
   {
      public static IApplicationBuilder UseFinishUnitOfWorkMiddleware(this IApplicationBuilder app)
      {
         app.UseMiddleware<FinishUnitOfWorkMiddleware>();
         
         return app;
      }
   }
}
