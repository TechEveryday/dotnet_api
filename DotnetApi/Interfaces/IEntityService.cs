using DotnetApi.Models;

namespace DotnetApi.Interfaces
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
