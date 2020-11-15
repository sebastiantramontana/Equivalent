using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Entities.Core;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Accounts.Domain.Entities
{
   public class Account : DistributableEntityBase
   {
      public Account(IDistributableId distributedId) : base(distributedId)
      {
      }

      public string Name { get; set; }
      public IEnumerable<User> Users { get; set; }
   }
}
