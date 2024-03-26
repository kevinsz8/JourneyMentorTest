using JourneyMentor.AirportService.Models;
using Microsoft.EntityFrameworkCore;

namespace JourneyMentor.AirportService.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.DefaultTypeMapping<Airport>();

        }

        public DbSet<Airport> Airports { get; set; }
    }
}