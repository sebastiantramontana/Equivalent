using Skyrmium.Domain.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<TEntity> where TEntity : IEntity
   {
      Task<IEnumerable<TEntity>> GetAsync();
      Task<TEntity> GetByIdAsync(long id);
      Task<TEntity> GetByDistributedIdAsync(IDistributableId distributableId);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);
   }
}
