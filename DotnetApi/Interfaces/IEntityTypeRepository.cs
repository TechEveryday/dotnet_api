using DotnetApi.Models;
using System.Collections.Generic;

namespace DotnetApi.Interfaces
{
  public interface IEntityTypeRepository
  {
    IEnumerable<EntityType> Get();
    IEnumerable<EntityType> GetById(int id);
    int Create(EntityType entityType);
    int Update(EntityType entityType);
    int Delete(EntityType id);
  }
}
