using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> Get();
        void Add(T entity);
        void Remove(T entity);

    }
}
