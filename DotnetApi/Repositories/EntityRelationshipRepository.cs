using DotnetApi.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class EntityRelationshipRepository
  {
    public enum EntityType
    {
      User = 2,
      Customer = 3,
      Package = 4
    }

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

    public IEnumerable<EntityRelationship> GetCouriersForManager(Guid entityId)
    {
      return _dbContext
        .EntityRelationship
        .Join(_dbContext.Entity, er => er.ChildEntityId, e => e.Id, (er, e) => new { er, e })
        .Where(cf => cf.er.EntityId == entityId && cf.e.TypeId == (int)EntityType.User)
        .Select(cf => cf.er)
        .ToArray();
    }

    public IEnumerable<EntityRelationship> GetDeliveriesForCourier(Guid entityId)
    {
      return _dbContext
        .EntityRelationship
        .Join(_dbContext.Entity, er => er.ChildEntityId, e => e.Id, (er, e) => new { er, e })
        .Where(cf => cf.er.EntityId == entityId && cf.e.TypeId == (int)EntityType.Package)
        .Select(cf => cf.er)
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
