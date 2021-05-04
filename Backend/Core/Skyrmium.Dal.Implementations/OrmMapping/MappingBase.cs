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
            .Property(e => e.Id)
            .HasColumnName(nameof(IDao.Id))
            .IsRequired()
            .ValueGeneratedOnAdd()
            .UseHiLo("DBSequenceHiLo");

         builder
            .Property(e => e.DistributedId)
            .HasColumnName(nameof(IDao.DistributedId))
            .IsRequired();

         Continue(builder);
      }

      protected abstract void Continue(EntityTypeBuilder<T> builder);
   }
}
