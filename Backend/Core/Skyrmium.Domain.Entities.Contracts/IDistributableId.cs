using System;

namespace Skyrmium.Domain.Entities.Contracts
{
   public interface IDistributableId : IEquatable<IDistributableId>
   {
      Guid Value { get; }
      bool IsNone { get; }
   }
}
