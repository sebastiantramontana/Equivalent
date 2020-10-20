using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public class Brand : DistributableEntityBase
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
