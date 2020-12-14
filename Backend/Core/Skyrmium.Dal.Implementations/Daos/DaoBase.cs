using Skyrmium.Dal.Contracts.Daos;

namespace Skyrmium.Dal.Implementations.Daos
{
   public abstract class DaoBase : IDao
   {
      public long Id { get; set; }
   }
}
