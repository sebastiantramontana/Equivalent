using Skyrmium.DomainModel.Entities.Contracts;
using System.Linq;

namespace Skyrmium.Dal.Contracts
{
   public interface IRepository<T> where T : IEntity
   {
      IQueryable<T> Get();
      void Add(T entity);
      void Remove(T entity);

   }
}
