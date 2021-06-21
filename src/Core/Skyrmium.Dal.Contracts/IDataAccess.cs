using Skyrmium.Dal.Contracts.Daos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Contracts
{
   public interface IDataAccess
   {
      IQueryable<TDao> Query<TDao>() where TDao : class, IDao;
      Task<TDao> Create<TDao>(TDao dao) where TDao : class, IDao;
      Task<IEnumerable<TDao>> Create<TDao>(IEnumerable<TDao> daos) where TDao : class, IDao;
      Task Update<TDao>(TDao dao) where TDao : class, IDao;
      Task Update<TDao>(IEnumerable<TDao> daos) where TDao : class, IDao;
      Task Delete<TDao>(TDao dao) where TDao : class, IDao;
      Task Delete<TDao>(IEnumerable<TDao> daos) where TDao : class, IDao;
   }
}
