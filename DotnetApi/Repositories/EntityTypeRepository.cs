using DotnetApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class EntityTypeRepository
  {
    private readonly PostgresContext _dbContext;

    public EntityTypeRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<EntityType> GetById(int id)
    {
      return _dbContext
        .EntityType
        .Where(cf => cf.Id == id)
        .ToArray();
    }

    public int Create(EntityType entityType)
    {
      _dbContext.Add<EntityType>(entityType);
      _dbContext.SaveChanges();

      return entityType.Id;
    }

    public IEnumerable<EntityType> Get()
    {
      return _dbContext
        .EntityType
        .ToArray();
    }

    public int Update(EntityType entityType)
    {
      _dbContext
          .EntityType
          .Update(entityType);

      _dbContext.SaveChanges();

      return entityType.Id;
    }

    public int Delete(EntityType entityType)
    {
      _dbContext
        .EntityType
        .Remove(entityType);

      _dbContext.SaveChanges();

      return entityType.Id;
    }
  }
}
