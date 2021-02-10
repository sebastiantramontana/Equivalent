using AutoMapper;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Adapters
{
   public class AdapterInitializer : AdapterInitializerBase
   {
      private readonly IMapper _mapper;

      public AdapterInitializer(IMapper mapper)
      {
         _mapper = mapper;
      }

      protected override IEnumerable<IAdapterConfigurator> GetAdapterConfigurators()
      {
         //REVISAR!!!
         throw new System.NotImplementedException();
      }
   }
}
