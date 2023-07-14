using DotnetApi.Models;

namespace DotnetApi.Services
{
    public interface IEntityService
    {
        /**
        * @param Entity entityToValidate
        * @return bool - returns false if the model is invalid
        */
        public abstract bool ValidateEntityModel(Entity entityToValidate);
    }
}
