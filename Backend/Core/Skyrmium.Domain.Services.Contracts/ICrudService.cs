using Skyrmium.Domain.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<T> where T : IEntity
   {
      IEnumerable<T> GetAll();
      IEnumerable<T> GetById(long id);
      IEnumerable<T> GetByDistributedId(IDistributableId distributedId);
      IEnumerable<T> Get(Expression<Func<T, bool>> condition);
      void Add(T entity);
      void Update(T entity);
      void Remove(T entity);
   }
}
