using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;
using BasicCrmSystem_Infrastructure.DatabaseContext;

namespace BasicCrmSystem_Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
