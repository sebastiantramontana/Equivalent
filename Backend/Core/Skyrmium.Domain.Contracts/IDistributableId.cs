using System;

namespace Skyrmium.Domain.Contracts
{
   public interface IDistributableId : IEquatable<IDistributableId>
   {
      Guid Value { get; }
      bool IsNone { get; }
   }
}
