//create new repository style class for Entity

using DotnetApi.Models;
using DotnetApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Repositories
{
  public class EntityRepository : IEntityRepository
  {
    private readonly PostgresContext _dbContext;

    public EntityRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Entity> GetById(Guid id)
    {
      try
      {
        return _dbContext
          .Entity
          .Where(cf => cf.Id == id)
          .ToArray();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Guid Create(Entity entity)
    {
      try
      {
        _dbContext.Add<Entity>(entity);
        _dbContext.SaveChanges();

        return entity.Id;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public IEnumerable<Entity> Get(int appId)
    {
      try
      {
        return _dbContext
          .Entity
          .Where(cf => cf.AppId == appId)
          .ToArray();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Guid Update(Entity entity)
    {
      try
      {
        _dbContext
            .Entity
            .Update(entity);
        _dbContext.SaveChanges();

        return entity.Id;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Guid Delete(Guid id)
    {
      try
      {
        Entity entity = _dbContext
          .Entity
          .Find(id);

        _dbContext
          .Entity
          .Remove(entity);

        _dbContext.SaveChanges();

        return entity.Id;
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }
}
