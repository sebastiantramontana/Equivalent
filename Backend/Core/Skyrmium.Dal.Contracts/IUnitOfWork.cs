namespace Skyrmium.Dal.Contracts
{
   public interface IUnitOfWork
   {
      void Finish();
      void Cancel();
   }
}
