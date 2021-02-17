namespace Skyrmium.Domain.Contracts.Entities
{
   public interface IOwnedEntity : IEntity
   {
      IDistributableId OwnedBy { get; }
   }
}
