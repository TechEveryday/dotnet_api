using DotnetApi.Models;
using DotnetApi.Repositories;
using System;
using System.Linq;

namespace DotnetApi.Services
{
  public class EntityTypeService
  {
    private readonly EntityTypeRepository _entityTypeRepository;

    public EntityTypeService(EntityTypeRepository entityTypeRepository)
    {
      _entityTypeRepository = entityTypeRepository;
    }

    public int create(EntityType entityType)
    {
      if (!this.ValidateModel(entityType))
        throw new Exception("Invalid EntityType model");

      return _entityTypeRepository.Create(entityType);
    }

    public int update(EntityType entityType)
    {
      if (!this.ValidateModel(entityType))
        throw new Exception("Invalid EntityType model");

      EntityType existingEntityType = _entityTypeRepository.GetById(entityType.Id).First();

      if (existingEntityType == null)
        throw new Exception("EntityType not found");

      return _entityTypeRepository.Update(entityType);
    }

    public int delete(int id)
    {
      EntityType existingEntityType = _entityTypeRepository.GetById(id).First();

      if (existingEntityType == null)
        throw new Exception("EntityType not found");

      return _entityTypeRepository.Delete(existingEntityType);
    }

    public EntityType[] get()
    {
      return (EntityType[])_entityTypeRepository.Get();
    }

    public EntityType[] getById(int id)
    {
      return (EntityType[])_entityTypeRepository.GetById(id);
    }

    /**
     * @param EntityType entityTypeToValidate
     * @return bool - returns false if the model is invalid
     */
    public bool ValidateModel(EntityType entityTypeToValidate)
    {
      return entityTypeToValidate != null
          && entityTypeToValidate.Id != 0
          && entityTypeToValidate.Name != null;
    }
  }
}
