using Microsoft.AspNetCore.Http;
using Skyrmium.Api.Contracts;
using Skyrmium.Api.Implementations.Errors;
using Skyrmium.Api.Implementations.Middlewares;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Api.Implementations
{
   public class IocBulkRegistrarCoreApi : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<IErrorMapper, ErrorMapper>();
         container.Register<LocalizationMiddleware>();
      }
   }
}
