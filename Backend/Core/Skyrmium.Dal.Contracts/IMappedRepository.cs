using Skyrmium.Domain.Entities.Contracts;

namespace Skyrmium.Dal.Contracts
{
   public interface IMappedRepository<TEntity, TDao> : IRepository<TEntity>
      where TEntity : IEntity
      where TDao : IDao
   {
   }
}
