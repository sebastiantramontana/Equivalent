using Microsoft.Extensions.Configuration;
using IDotNetConfig = Microsoft.Extensions.Configuration.IConfiguration;
using ISkyrmiumConfig = Skyrmium.Infrastructure.Contracts.IConfiguration;

namespace Skyrmium.Equivalent.Measurement.Api
{
   internal class Configuration : ISkyrmiumConfig
   {
      public Configuration(IDotNetConfig dotNetConfig)
      {
         this.ConnectionString = dotNetConfig.GetValue<string>("ConnectionString");
      }
      public string ConnectionString { get; init; }
   }
}
