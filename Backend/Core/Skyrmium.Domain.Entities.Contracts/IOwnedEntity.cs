namespace Skyrmium.Domain.Entities.Contracts
{
   public interface IOwnedEntity
   {
      IDistributableId OwnedBy { get; }
   }
}
