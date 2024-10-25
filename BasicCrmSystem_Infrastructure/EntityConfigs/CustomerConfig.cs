using BasicCrmSystem_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicCrmSystem_Infrastructure.EntityConfigs
{
    internal class CustomerConfig : BaseEntityConfig<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Property(x => x.FirstName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnOrder(2);

            builder.Property(x => x.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnOrder(3);

            builder.Property(x => x.Email)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(200)")
                .HasColumnOrder(4);

            builder.Property(x => x.RegionId)
                .IsRequired(true)
                .HasColumnOrder(5);


            base.Configure(builder);
        }
    }
}
