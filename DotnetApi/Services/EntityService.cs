using DotnetApi.Models;
using DotnetApi.Interfaces;
using System;
using System.Linq;

namespace DotnetApi.Services
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Guid create(Entity entity)
        {
            if (!this.ValidateEntityModel(entity))
                throw new Exception("Invalid Entity model");

            return _entityRepository.Create(entity);
        }

        public Guid update(Entity entity)
        {
            if (!this.ValidateEntityModel(entity))
                throw new Exception("Invalid Entity model");

            Entity existingEntity = _entityRepository.GetById(entity.Id).First();

            if (existingEntity == null)
                throw new Exception("Entity not found");

            return _entityRepository.Update(entity);
        }

        public Guid delete(Guid id)
        {
            Entity existingEntity = _entityRepository.GetById(id).First();

            if (existingEntity == null)
                throw new Exception("Entity not found");

            return _entityRepository.Delete(existingEntity);
        }

        public Entity[] get(int appId)
        {
            return (Entity[])_entityRepository.Get(appId);
        }

        public Entity[] getById(Guid id)
        {
            return (Entity[])_entityRepository.GetById(id);
        }

        /**
         * @param City entityToValidate
         * @return bool - returns false if the model is invalid
         */
        public bool ValidateEntityModel(Entity entityToValidate)
        {
            return entityToValidate != null
                && entityToValidate.AppId != 0
                && entityToValidate.TypeId != 0;
        }
    }
}
