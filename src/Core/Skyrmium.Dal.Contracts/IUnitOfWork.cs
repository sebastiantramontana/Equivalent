using System.Threading.Tasks;

namespace Skyrmium.Dal.Contracts
{
   public interface IUnitOfWork
   {
      Task Finish();
      void Cancel();
   }
}
