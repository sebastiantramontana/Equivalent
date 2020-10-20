using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public abstract class DistributableEntityBase : EntityBase, IDistributableEntity
    {
        public Guid Guid { get; set; }
        public bool Equals(IDistributableEntity other)
        {
            return !ReferenceEquals(other, null) && this.Guid.Equals(other.Guid);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as IDistributableEntity);
        }
        public override int GetHashCode()
        {
            return this.Guid.GetHashCode();
        }
        public static bool operator ==(DistributableEntityBase e1, DistributableEntityBase e2)
        {
            return !ReferenceEquals(e1, null) && !ReferenceEquals(e2, null) && e1.Equals(e2);
        }
        public static bool operator !=(DistributableEntityBase e1, DistributableEntityBase e2)
        {
            return ReferenceEquals(e1, null) || ReferenceEquals(e2, null) || !e1.Equals(e2);
        }
        public static bool operator ==(DistributableEntityBase e1, IDistributableEntity e2)
        {
            return !ReferenceEquals(e1, null) && !ReferenceEquals(e2, null) && e1.Equals(e2);
        }
        public static bool operator !=(DistributableEntityBase e1, IDistributableEntity e2)
        {
            return ReferenceEquals(e1, null) || ReferenceEquals(e2, null) || !e1.Equals(e2);
        }

        public static bool operator ==(IDistributableEntity e1, DistributableEntityBase e2)
        {
            return !ReferenceEquals(e1, null) && !ReferenceEquals(e2, null) && e1.Equals(e2);
        }
        public static bool operator !=(IDistributableEntity e1, DistributableEntityBase e2)
        {
            return ReferenceEquals(e1, null) || ReferenceEquals(e2, null) || !e1.Equals(e2);
        }
    }
}
