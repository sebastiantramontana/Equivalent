using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public abstract class EntityBase : IEntity
    {
        public long Id { get; set; }
    }
}
