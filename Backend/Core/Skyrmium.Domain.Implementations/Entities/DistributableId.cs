using Skyrmium.Domain.Contracts.Entities;
using System;

namespace Skyrmium.Domain.Implementations.Entities
{
   public class DistributableId : IDistributableId
   {
      public static IDistributableId None { get; } = new DistributableId(Guid.Empty);

      public static IDistributableId Create()
      {
         return new DistributableId(Guid.NewGuid());
      }

      public static IDistributableId Instance(Guid value)
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

      public bool Equals(Guid? other)
      {
         return other.HasValue
            ? other.Value == this.Value
            : this.IsNone;
      }

      public bool Equals(IDistributableId? other)
      {
         return other is not null && other.Value == this.Value;
      }

      public override int GetHashCode()
      {
         return this.Value.GetHashCode();
      }

      public static bool operator ==(DistributableId? left, DistributableId? right)
      {
         return left?.Equals(right) ?? false;
      }

      public static bool operator !=(DistributableId? left, DistributableId? right)
      {
         return !(left == right);
      }

      //public static bool operator ==(DistributableId? left, Guid? right)
      //{
      //   return left?.Equals(right) ?? false;
      //}

      //public static bool operator !=(DistributableId? left, Guid? right)
      //{
      //   return !(left == right);
      //}

      //public static bool operator ==(Guid? left, DistributableId? right)
      //{
      //   return left?.Equals(right) ?? false;
      //}

      //public static bool operator !=(Guid? left, DistributableId? right)
      //{
      //   return !(left == right);
      //}

      //public static implicit operator Guid?(DistributableId? distributableId)
      //{
      //   return distributableId is not null && !distributableId.IsNone
      //      ? distributableId.Value
      //      : null;
      //}

      //public static implicit operator DistributableId(Guid? guid)
      //{
      //   return guid.HasValue
      //      ? (DistributableId)Instance(guid.Value)
      //      : (DistributableId)None;
      //}
   }
}
