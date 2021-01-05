using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public interface IDalAdapter<TEntity, TDao> : IExpressionAdapter<TEntity, TDao>
      where TEntity : IEntity
      where TDao : IDao
   {
   }
}
