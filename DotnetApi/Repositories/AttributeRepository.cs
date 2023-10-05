using DotnetApi.Models;
using DotnetApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class AttributeRepository : IAttributeRepository
  {
    private readonly PostgresContext _dbContext;

    public AttributeRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Models.Attribute> GetById(Guid id)
    {
      return _dbContext
        .Attribute
        .Where(cf => cf.Id == id)
        .ToArray();
    }

    public Guid Create(Models.Attribute attribute)
    {
      _dbContext.Add<Models.Attribute>(attribute);
      _dbContext.SaveChanges();

      return attribute.Id;
    }

    public IEnumerable<Models.Attribute> Get(Guid entityId)
    {
      return _dbContext
        .Attribute
        .Where(cf => cf.EntityId == entityId)
        .ToArray();
    }

    public Guid Update(Models.Attribute attribute)
    {
      _dbContext
          .Attribute
          .Update(attribute);

      _dbContext.SaveChanges();

      return attribute.Id;
    }

    public Guid Delete(Models.Attribute attribute)
    {
      _dbContext
        .Attribute
        .Remove(attribute);

      _dbContext.SaveChanges();

      return attribute.Id;
    }
  }
}
