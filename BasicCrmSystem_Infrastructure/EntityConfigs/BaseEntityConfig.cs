using BasicCrmSystem_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrmSystem_Infrastructure.EntityConfigs
{
    internal class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true).HasColumnOrder(1);
            builder.Property(x => x.CreatedAt).IsRequired(false).HasColumnType("datetime2");
            builder.Property(x => x.UpdatedAt).IsRequired(false).HasColumnType("datetime2");
        }
    }
}
