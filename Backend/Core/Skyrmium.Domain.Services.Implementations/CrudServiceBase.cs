using Skyrmium.Dal.Contracts;
using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class CrudServiceBase<T> : ICrudService<T> where T : IEntity
   {
      protected CrudServiceBase(IRepository<T> repository)
      {
         this.Repository = repository;
      }

      protected IRepository<T> Repository { get; }

      public void Add(T entity)
      {
         this.Repository.Add(entity);
      }

      public IEnumerable<T> Get(Expression<Func<T, bool>> condition)
      {
         return this.Repository.Get(condition);
      }

      public IEnumerable<T> GetAll()
      {
         return this.Repository.GetAll();
      }

      public T GetByDistributedId(IDistributableId distributedId)
      {
         return this.Repository.GetByDistributedId(distributedId);
      }

      public T GetById(long id)
      {
         return this.Repository.GetById(id);
      }

      public void Remove(T entity)
      {
         this.Repository.Remove(entity);
      }

      public void Update(T entity)
      {
         this.Repository.Update(entity);
      }
   }
}
