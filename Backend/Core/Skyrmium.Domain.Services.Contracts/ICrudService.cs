using Skyrmium.Domain.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<TEntity> where TEntity : IEntity
   {
      Task<IEnumerable<TEntity>> GetAsync();
      TEntity GetById(long id);
      TEntity GetByDistributedId(IDistributableId distributableId);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);
   }
}
