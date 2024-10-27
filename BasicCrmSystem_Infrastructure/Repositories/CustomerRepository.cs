using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;
using BasicCrmSystem_Infrastructure.DatabaseContext;

namespace BasicCrmSystem_Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
