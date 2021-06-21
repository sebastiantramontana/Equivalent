using Skyrmium.Localization.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Localization.Abstractions
{
   public abstract class LocalizerFactoryBase<TLocalizer> : ILocalizerFactory<TLocalizer> where TLocalizer : ILocalizer
   {
      private readonly IEnumerable<TLocalizer> _localizers;

      protected LocalizerFactoryBase(IEnumerable<TLocalizer> localizers)
      {
         _localizers = localizers;
      }

      public TLocalizer Create(ICulture culture)
      {
         return _localizers.SingleOrDefault(l => l.Culture.Equals(culture))
            ?? throw new NotImplementedException($"Culture {culture} not implemented");
      }
   }
}
