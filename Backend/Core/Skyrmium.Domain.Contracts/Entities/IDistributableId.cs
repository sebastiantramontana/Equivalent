using System;

namespace Skyrmium.Domain.Contracts.Entities
{
   public interface IDistributableId : IEquatable<IDistributableId>
   {
      Guid Value { get; }
      bool IsNone { get; }
   }
}
