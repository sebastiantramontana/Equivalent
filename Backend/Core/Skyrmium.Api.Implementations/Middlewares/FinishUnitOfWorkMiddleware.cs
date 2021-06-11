using Microsoft.AspNetCore.Http;
using Skyrmium.Dal.Contracts;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations.Middlewares
{
   public class FinishUnitOfWorkMiddleware
   {
      private readonly RequestDelegate _next;

      public FinishUnitOfWorkMiddleware(RequestDelegate next)
      {
         _next = next;
      }
      public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
      {
         await _next.Invoke(context);

         if (HttpMethods.IsGet(context.Request.Method))
            return;

         await unitOfWork.Finish();
      }
   }
}
