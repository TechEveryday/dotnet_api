using DotnetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class EntityRepository
  {
    private readonly PostgresContext _dbContext;

    public EntityRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Entity> GetById(Guid id)
    {
      return _dbContext
        .Entity
        .Where(cf => cf.Id == id)
        .ToArray();
    }

    public Guid Create(Entity entity)
    {
      _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.entity ON");
      _dbContext.Add<Entity>(entity);
      _dbContext.SaveChanges();
      _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.entity OFF");

      return entity.Id;
    }

    public IEnumerable<Entity> Get(int appId)
    {
      return _dbContext
        .Entity
        .Where(cf => cf.AppId == appId)
        .ToArray();
    }

    public Guid Update(Entity entity)
    {
      _dbContext
          .Entity
          .Update(entity);
      _dbContext.SaveChanges();

      return entity.Id;
    }

    public Guid Delete(Entity entity)
    {
      _dbContext
        .Entity
        .Remove(entity);

      _dbContext.SaveChanges();

      return entity.Id;
    }
  }
}
