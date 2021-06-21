using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Contracts.Daos;

namespace Skyrmium.Dal.Implementations.OrmMapping
{
   public abstract class MappingBase<T> : IEntityTypeConfiguration<T> where T : class, IDao
   {
      private readonly string _tableName;

      protected MappingBase(string tableName)
      {
         _tableName = tableName;
      }

      public void Configure(EntityTypeBuilder<T> builder)
      {
         builder.ToTable(_tableName);

         builder
            .Property(d => d.Id)
            .HasColumnName(nameof(IDao.Id))
            .ValueGeneratedNever()
            .IsRequired(true);

         builder
            .HasKey(d => d.Id)
            .HasName(nameof(IDao.Id))
            .IsClustered(false);

         Continue(builder);
      }

      protected abstract void Continue(EntityTypeBuilder<T> builder);
   }
}
