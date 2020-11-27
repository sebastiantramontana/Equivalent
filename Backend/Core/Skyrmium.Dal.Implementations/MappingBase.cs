using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Contracts;

namespace Skyrmium.Dal.Implementations
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
            .HasColumnName("Id")
            .IsRequired()
            .ValueGeneratedOnAdd()
            .UseHiLo("DBSequenceHiLo")
            .UseIdentityColumn();

         builder.HasKey(e => e.Id)
            .IsClustered(true);

         Continue(builder);
      }

      protected abstract void Continue(EntityTypeBuilder<T> builder);
   }
}
