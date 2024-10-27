using BasicCrmSystem_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrmSystem_Infrastructure.EntityConfigs
{
    internal class RegionConfig : BaseEntityConfig<Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {

            builder.Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(2);

            //Foreign Key
            builder.HasMany(x => x.Customers)
                           .WithOne(x => x.Region)
                           .HasForeignKey(x => x.RegionId)
                           .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
