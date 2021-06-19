using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations.Middlewares
{
   public class LocalizationMiddleware : IMiddleware
   {
      public async Task InvokeAsync(HttpContext context, RequestDelegate next)
      {
         var cultureQuery = context.Request.Query["culture"];
         var requestCulture = cultureQuery.Count == 0 ? SupportedCultures.EnUS : SupportedCultures.FromIsoCode(cultureQuery[0]);

         var currentCulture = context.RequestServices.GetRequiredService<ICulture>();

         if (currentCulture != requestCulture)
            currentCulture.SetNewCulture(requestCulture.CultureEnum, requestCulture.IsoCode);

         await next.Invoke(context);
      }
   }
}
