using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Api.Implementations.Middlewares
{
   public class LocalizationMiddleware
   {
      private readonly RequestDelegate _next;

      public LocalizationMiddleware(RequestDelegate next)
      {
         _next = next;
      }
      public async Task Invoke(HttpContext context)
      {
         var cultureQuery = context.Request.Query["culture"];
         var culture = cultureQuery.Count == 0 ? SupportedCultures.EnUS : Culture.FromIsoCode(cultureQuery[0]);

         var container = context.RequestServices.GetRequiredService<IContainer>();
         container.Register(culture);

         await _next.Invoke(context);
      }
   }
}
