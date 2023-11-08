using DotnetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class EntityRelationshipRepository
  {
    private readonly PostgresContext _dbContext;

    public EntityRelationshipRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<EntityRelationship> Get(Guid entityId)
    {
      return _dbContext
        .EntityRelationship
        .Where(cf => cf.EntityId == entityId)
        .ToArray();
    }

    public IEnumerable<EntityRelationship> GetById(Guid entityId, Guid childEntityId)
    {
      return _dbContext
        .EntityRelationship
        .Where(cf => cf.EntityId == entityId && cf.ChildEntityId == childEntityId)
        .ToArray();
    }

    public Guid Create(EntityRelationship entityRelationship)
    {
      _dbContext.Add<EntityRelationship>(entityRelationship);
      _dbContext.SaveChanges();

      return entityRelationship.EntityId;
    }

    // public Guid Update(EntityRelationship entityRelationship)
    // {
    //   _dbContext
    //       .EntityRelationship
    //       .Update(entityRelationship);
    //   _dbContext.SaveChanges();

    //   return entityRelationship.EntityId;
    // }

    public Guid Delete(EntityRelationship entityRelationship)
    {
      _dbContext
        .EntityRelationship
        .Remove(entityRelationship);

      _dbContext.SaveChanges();

      return entityRelationship.EntityId;
    }
  }
}
