using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;
using BasicCrmSystem_Infrastructure.DatabaseContext;

namespace BasicCrmSystem_Infrastructure.Repositories
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(PostgreSqlDbContext context) : base(context)
        {
        }
    }
}
