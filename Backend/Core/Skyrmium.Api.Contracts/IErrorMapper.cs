using System;

namespace Skyrmium.Api.Contracts
{
   public interface IErrorMapper
   {
      object CreateErrorResult(Exception exception);
   }
}
