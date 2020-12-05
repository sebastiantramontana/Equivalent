using Skyrmium.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<TEntity> where TEntity : IEntity
   {
      IEnumerable<TEntity> Get();
      TEntity GetById(long id);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);
   }
}
