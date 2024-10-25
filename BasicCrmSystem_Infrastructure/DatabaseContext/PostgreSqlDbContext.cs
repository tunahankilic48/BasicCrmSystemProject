using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Infrastructure.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace BasicCrmSystem_Infrastructure.DatabaseContext
{
    public class PostgreSqlDbContext : DbContext
    {
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options) : base(options)
        {
        }

        public DbSet<Region> Regions{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegionConfig())
                        .ApplyConfiguration(new RoleConfig())
                        .ApplyConfiguration(new UserConfig())
                        .ApplyConfiguration(new CustomerConfig());

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
