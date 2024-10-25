using BasicCrmSystem_Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BasicCrmSystem_Infrastructure.EntityConfigs
{
    internal class RoleConfig : BaseEntityConfig<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.Property(x => x.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnOrder(2);

            //Foreign Key
            builder.HasMany(x => x.Users)
                           .WithOne(x => x.Role)
                           .HasForeignKey(x => x.RoleId)
                           .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
