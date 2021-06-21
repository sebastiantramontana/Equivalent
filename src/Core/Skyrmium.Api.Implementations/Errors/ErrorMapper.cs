using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skyrmium.Api.Contracts;
using Skyrmium.Dal.Contracts.Exceptions;
using Skyrmium.Domain.Contracts.Exceptions;
using System;

namespace Skyrmium.Api.Implementations.Errors
{
   public class ErrorMapper : IErrorMapper
   {
      public object CreateErrorResult(Exception exception)
      {
         return exception switch
         {
            BusinessException businessException => new BadRequestObjectResult(new { Type = ErrorType.Bussiness, businessException.Title, businessException.Message }),
            DataObjectNotFoundException dataObjectNotFoundException => new NotFoundObjectResult(new { Type = ErrorType.DataNotFound, dataObjectNotFoundException.Message }),
            EntityAlreadyExistsException entityAlreadyExistsException => new BadRequestObjectResult(new { Type = ErrorType.EntityAlreadyExists, entityAlreadyExistsException.Message }),
            MissingIdForUpdateException => new BadRequestObjectResult(new { Type = ErrorType.MissingIdForUpdate }),
            MissingIdForDeleteException => new BadRequestObjectResult(new { Type = ErrorType.MissingIdForDelete }),
            _ => new StatusCodeResult(StatusCodes.Status500InternalServerError),
         };
      }
   }
}
