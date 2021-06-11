using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Skyrmium.Api.Contracts;
using Skyrmium.Dal.Contracts;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations.Errors
{
   public class ExceptionFilter : IAsyncExceptionFilter
   {
      private readonly IErrorMapper _errorMapper;
      private readonly IUnitOfWork _unitOfWork;

      public ExceptionFilter(IErrorMapper errorMapper, IUnitOfWork unitOfWork)
      {
         _errorMapper = errorMapper;
         _unitOfWork = unitOfWork;
      }

      public Task OnExceptionAsync(ExceptionContext context)
      {
         _unitOfWork.Cancel();

         context.ExceptionHandled = true;
         context.Result = _errorMapper.CreateErrorResult(context.Exception) as IActionResult;

         return Task.CompletedTask;
      }
   }
}

