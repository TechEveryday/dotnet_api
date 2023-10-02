using DotnetApi.Models;
using DotnetApi.Interfaces;

namespace DotnetApi.Services
{
    public class EntityService : IEntityService
    {
        /**
         * @param City entityToValidate
         * @return bool - returns false if the model is invalid
         */
        public bool ValidateEntityModel(Entity entityToValidate)
        {
            return entityToValidate.AppId != 0
                && entityToValidate.TypeId != 0;
        }
    }
}
