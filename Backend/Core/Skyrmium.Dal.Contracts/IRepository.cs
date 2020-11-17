using Skyrmium.Domain.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skyrmium.Dal.Contracts
{
   public interface IRepository<T> where T : IEntity
   {
      IEnumerable<T> GetAll();
      IEnumerable<T> Get(Expression<Func<T, bool>> condition);
      void Add(T entity);
      void Update(T entity);
      void Remove(T entity);

   }
}
