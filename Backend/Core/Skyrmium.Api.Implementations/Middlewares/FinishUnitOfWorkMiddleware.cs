using Microsoft.AspNetCore.Http;
using Skyrmium.Dal.Contracts;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations.Middlewares
{
   public class FinishUnitOfWorkMiddleware
   {
      private readonly RequestDelegate _next;
      private readonly IUnitOfWork _unitOfWork;

      public FinishUnitOfWorkMiddleware(RequestDelegate next)
      {
         _next = next;
         //_unitOfWork = unitOfWork;
      }
      public async Task Invoke(HttpContext context)
      {
         await _next.Invoke(context);

         //await _unitOfWork.Finish();
      }
   }
}
