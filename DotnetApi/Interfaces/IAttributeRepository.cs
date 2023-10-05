using DotnetApi.Models;
using System;
using System.Collections.Generic;

namespace DotnetApi.Interfaces
{
  public interface IAttributeRepository
  {
    IEnumerable<Models.Attribute> Get(Guid entityId);
    IEnumerable<Models.Attribute> GetById(Guid id);
    Guid Create(Models.Attribute attribute);
    Guid Update(Models.Attribute attribute);
    Guid Delete(Models.Attribute id);
  }
}
