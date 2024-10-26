using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;
using BasicCrmSystem_Infrastructure.DatabaseContext;

namespace BasicCrmSystem_Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
