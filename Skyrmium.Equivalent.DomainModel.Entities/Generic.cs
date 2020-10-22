using Skyrmium.DomainModel.Entities.Contracts;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class Generic : DistributableEntityBase
   {
      public string Name { get; set; }

      public override string ToString()
      {
         return this.Name;
      }
   }
}
