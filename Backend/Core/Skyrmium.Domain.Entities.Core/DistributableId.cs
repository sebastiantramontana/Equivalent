using Skyrmium.Domain.Entities.Contracts;
using System;

namespace Skyrmium.Domain.Entities.Core
{
   public class DistributableId : IDistributableId
   {
      public static DistributableId None { get; } = new DistributableId(Guid.Empty);

      public static DistributableId Create()
      {
         return new DistributableId(Guid.NewGuid());
      }

      public static DistributableId Instance(Guid value)
      {
         if (value == Guid.Empty)
         {
            throw new ArgumentException($"{nameof(Instance)} argument {value} cannot be Guid.Empty!");
         }

         return new DistributableId(value);
      }

      private DistributableId(Guid value)
      {
         this.Value = value;
         this.IsNone = this.Value == Guid.Empty;
      }

      public Guid Value { get; }

      public bool IsNone { get; }

      public override bool Equals(object? obj)
      {
         return Equals(obj as IDistributableId);
      }

      public bool Equals(IDistributableId? other)
      {
         return (other is not null) && other.Value == this.Value;
      }

      public override int GetHashCode()
      {
         return this.Value.GetHashCode();
      }

      public static bool operator ==(DistributableId left, DistributableId right)
      {
         return left is not null && left.Equals(right);
      }

      public static bool operator !=(DistributableId left, DistributableId right)
      {
         return !(left == right);
      }
   }
}
