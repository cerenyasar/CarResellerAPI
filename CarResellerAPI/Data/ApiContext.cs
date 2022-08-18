using Microsoft.EntityFrameworkCore;
using CarResellerAPI.Models;

namespace CarResellerAPI.Data
{
    public class ApiContext : DbContext     
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
    }
}
