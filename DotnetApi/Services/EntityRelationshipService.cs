using DotnetApi.Models;
using DotnetApi.Repositories;
using System;
using System.Linq;

namespace DotnetApi.Services
{
  public class EntityRelationshipService
  {
    private readonly EntityRelationshipRepository _entityRelationshipRepository;

    public EntityRelationshipService(EntityRelationshipRepository entityRelationshipRepository)
    {
      _entityRelationshipRepository = entityRelationshipRepository;
    }

    public Guid create(EntityRelationship entityRelationship)
    {
      if (!this.ValidateEntityModel(entityRelationship))
        throw new Exception("Invalid EntityRelationship model");

      return _entityRelationshipRepository.Create(entityRelationship);
    }

    // public Guid update(EntityRelationship entityRelationship)
    // {
    //   if (!this.ValidateEntityModel(entityRelationship))
    //     throw new Exception("Invalid EntityRelationship model");

    //   EntityRelationship existingEntityRelationship = _entityRelationshipRepository.GetById(entityRelationship.EntityId, entityRelationship.ChildEntityId).First();

    //   if (existingEntityRelationship == null)
    //     throw new Exception("EntityRelationship not found");

    //   return _entityRelationshipRepository.Update(entityRelationship);
    // }

    public Guid delete(Guid entityId, Guid childEntityId)
    {
      EntityRelationship existingEntityRelationship = _entityRelationshipRepository.GetById(entityId, childEntityId).First();

      if (existingEntityRelationship == null)
        throw new Exception("EntityRelationship not found");

      return _entityRelationshipRepository.Delete(existingEntityRelationship);
    }

    public EntityRelationship[] get(Guid entityId)
    {
      return (EntityRelationship[])_entityRelationshipRepository.Get(entityId);
    }

    /**
     * @param City entityRelationshipToValidate
     * @return bool - returns false if the model is invalid
     */
    public bool ValidateEntityModel(EntityRelationship entityRelationshipToValidate)
    {
      return entityRelationshipToValidate != null;
    }
  }
}
