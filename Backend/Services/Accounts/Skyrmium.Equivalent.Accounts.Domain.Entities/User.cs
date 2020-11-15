using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Entities.Core;

namespace Skyrmium.Equivalent.Accounts.Domain.Entities
{
   public class User : DistributableEntityBase
   {
      public User(IDistributableId distributedId) : base(distributedId)
      {
      }

      public string Name { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }
      public string Email { get; set; }
   }
}
