using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Models
{
  public class PostgresContext : DbContext
  {
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
    public DbSet<App> App { get; set; }
    public DbSet<Entity> Entity { get; set; }
    public DbSet<EntityType> EntityType { get; set; }
    public DbSet<Attribute> Attribute { get; set; }
    public DbSet<AttributeType> AttributeType { get; set; }
    public DbSet<Record> Record { get; set; }
    public DbSet<EntityRelationship> EntityRelationship { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // => optionsBuilder.UseNpgsql("Host=localhost;Database=localdb;Username=user;Password=password");
  }
}
