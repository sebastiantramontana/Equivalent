using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Contracts.Daos;

namespace Skyrmium.Dal.Implementations.Mapping
{
   public abstract class OwnedMappingBase<T> : MappingBase<T> where T : class, IOwnedDao
   {
      protected OwnedMappingBase(string tableName) : base(tableName)
      {
      }

      protected override void Continue(EntityTypeBuilder<T> builder)
      {
         builder
            .Property(e => e.OwnedBy)
            .HasColumnName(nameof(IOwnedDao.OwnedBy))
            .IsRequired();

         ContinueOwned(builder);
      }

      protected abstract void ContinueOwned(EntityTypeBuilder<T> builder);
   }
}
