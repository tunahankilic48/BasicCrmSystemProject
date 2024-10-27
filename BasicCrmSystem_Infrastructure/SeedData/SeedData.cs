using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Infrastructure.DatabaseContext;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BasicCrmSystem_Infrastructure.SeedData
{
    public class SeedData
    {
        public async static Task Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                PostgreSqlDbContext context = serviceScope.ServiceProvider.GetService<PostgreSqlDbContext>()!;

                List<Region> regions = new List<Region>();
                List<Role> roles = new List<Role>();
                List<User> users = new List<User>();
                List<Customer> customers = new List<Customer>();


                if (!context.Regions.Any())
                {
                    regions.Add(new Region()
                    {
                        Name = "Asia",
                        CreatedAt = DateTime.Now
                    });
                    regions.Add(new Region()
                    {
                        Name = "Europe",
                        CreatedAt = DateTime.Now
                    });
                    regions.Add(new Region()
                    {
                        Name = "North America",
                        CreatedAt = DateTime.Now
                    });
                    regions.Add(new Region()
                    {
                        Name = "South AMerica",
                        CreatedAt = DateTime.Now
                    });
                    regions.Add(new Region()
                    {
                        Name = "Africa",
                        CreatedAt = DateTime.Now
                    });
                    regions.Add(new Region()
                    {
                        Name = "Australia",
                        CreatedAt = DateTime.Now
                    });
                    await context.Regions.AddRangeAsync(regions);
                    await context.SaveChangesAsync();
                }

                if (!context.Roles.Any())
                {
                    roles.Add(new Role()
                    {
                        Name = "Admin",
                        CreatedAt = DateTime.Now
                    });
                    roles.Add(new Role()
                    {
                        Name = "Customer",
                        CreatedAt = DateTime.Now
                    });
                    await context.Roles.AddRangeAsync(roles);
                    await context.SaveChangesAsync();
                }

                if (!context.Users.Any())
                {
                    users.Add(new User()
                    {
                        Username = "AdminAdmin",
                        Password = "1234",
                        RoleId = 1,
                        CreatedAt = DateTime.Now
                    });
                    users.Add(new User()
                    {
                        Username = "Yonetmen",
                        Password = "4321",
                        RoleId = 1,
                        CreatedAt = DateTime.Now
                    });
                    await context.Users.AddRangeAsync(users);
                    await context.SaveChangesAsync();
                }

                if (!context.Customers.Any())
                {
                    var customerFaker = new Faker<Customer>()
                       .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                       .RuleFor(x => x.LastName, y => y.Name.LastName())
                       .RuleFor(x => x.Email, y => y.Internet.Email())
                       .RuleFor(x => x.RegionId, y => y.Random.Int(1, 6))
                       .RuleFor(x => x.CreatedAt, y => y.Date.Between(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(20)));

                    customers = customerFaker.Generate(40);
                    
                    await context.Customers.AddRangeAsync(customers);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
