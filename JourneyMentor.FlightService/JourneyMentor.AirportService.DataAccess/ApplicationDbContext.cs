using JourneyMentor.FlightService.Models;
using Microsoft.EntityFrameworkCore;

namespace JourneyMentor.FlightService.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.DefaultTypeMapping<Flight>();
        }

        public DbSet<Flight> Flights { get; set; }
    }
}