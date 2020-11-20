using Skyrmium.Domain.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<T> where T : IEntity
   {
      IEnumerable<T> GetAll();
      IEnumerable<T> Get(Expression<Func<T, bool>> condition);
      T GetById(long id);
      T GetByDistributedId(IDistributableId distributedId);
      void Add(T entity);
      void Update(T entity);
      void Remove(T entity);
   }
}
