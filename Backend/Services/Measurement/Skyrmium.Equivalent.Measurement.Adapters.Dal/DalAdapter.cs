using AutoMapper;
using Skyrmium.Adapters.Implementations;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public class DalAdapter<TEntity, TDao> : ExpressionAdapterBase<TEntity, TDao>, IDalAdapter<TEntity, TDao>
      where TEntity : IEntity
      where TDao : IDao
   {
      public DalAdapter(IMapper mapper) : base(mapper)
      {
      }
   }
}
