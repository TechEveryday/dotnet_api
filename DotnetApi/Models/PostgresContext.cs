using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Models
{
  public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
        public DbSet<CityForecast> CityForecast { get; set; }
        public DbSet<WeatherForecast> WeatherForecast
        { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // => optionsBuilder.UseNpgsql("Host=localhost;Database=localdb;Username=user;Password=password");
    }
}
