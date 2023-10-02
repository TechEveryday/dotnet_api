using DotnetApi.Models;
using System;
using System.Collections.Generic;

namespace DotnetApi.Interfaces
{
  public interface IEntityRepository
  {
    IEnumerable<Entity> Get(int appId);
    IEnumerable<Entity> GetById(Guid id);
    Guid Create(Entity entity);
    Guid Update(Entity entity);
    Guid Delete(Guid id);
  }
}
