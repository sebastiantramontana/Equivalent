using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public interface IDistributableEntity : IEntity, IEquatable<IDistributableEntity>
    {
        Guid Guid { get; }
    }
}
