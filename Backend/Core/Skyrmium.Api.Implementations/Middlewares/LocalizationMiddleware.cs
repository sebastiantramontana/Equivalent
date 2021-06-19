using Microsoft.AspNetCore.Http;
using Skyrmium.Localization.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations.Middlewares
{
   public class LocalizationMiddleware
   {
      private readonly RequestDelegate _next;

      public LocalizationMiddleware(RequestDelegate next)
      {
         _next = next;
      }

      public Task InvokeAsync(HttpContext context, ISupportedCultures supportedCultures, ICurrentCulture currentCulture)
      {
         var cultureQuery = context.Request.Query["culture"];

         if (cultureQuery.Any())
         {
            ModifyCulture(cultureQuery.First(), supportedCultures, currentCulture);
         }

         return _next.Invoke(context);
      }

      private void ModifyCulture(string newIsoCodeCulture, ISupportedCultures supportedCultures, ICurrentCulture currentCulture)
      {
         var requestCulture = supportedCultures.FromIsoCode(newIsoCodeCulture);

         if (currentCulture.Culture != requestCulture)
            currentCulture.Culture = requestCulture;
      }
   }
}
