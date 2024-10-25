using BasicCrmSystem_Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BasicCrmSystem_Infrastructure.EntityConfigs
{
    internal class UserConfig : BaseEntityConfig<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Username)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnOrder(2);

            builder.Property(x => x.Password)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(100)")
                .HasColumnOrder(3);

            builder.Property(x => x.RoleId)
                .IsRequired(true)
                .HasColumnOrder(4);

            base.Configure(builder);
        }
    }
}
