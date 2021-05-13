using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Contracts.Daos;
using System.Runtime.InteropServices;

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
            .ValueGeneratedOnAdd()
            .IsRequired(true)
            .UseHiLo($"{_tableName}_SequenceHiLo");

         builder
            .HasKey(d => d.Id)
            .HasName(nameof(IDao.Id))
            .IsClustered(true);

         builder
            .HasAlternateKey(d => d.DistributedId)
            .HasName(nameof(IDao.DistributedId))
            .IsClustered(false);

         builder
            .Property(d => d.DistributedId)
            .HasColumnName(nameof(IDao.DistributedId))
            .IsRequired(true)
            .ValueGeneratedNever();

         Continue(builder);
      }

      protected abstract void Continue(EntityTypeBuilder<T> builder);
   }
}
