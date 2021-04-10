using System;

namespace Skyrmium.Domain.Contracts.Entities
{
   public interface IDistributableId : IEquatable<IDistributableId>, IEquatable<Guid?>
   {
      Guid Value { get; }
      bool IsNone { get; }
   }
}
