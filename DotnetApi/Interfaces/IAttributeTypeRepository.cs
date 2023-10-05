using DotnetApi.Models;
using System.Collections.Generic;

namespace DotnetApi.Interfaces
{
  public interface IAttributeTypeRepository
  {
    IEnumerable<AttributeType> Get();
    IEnumerable<AttributeType> GetById(int id);
    int Create(AttributeType attributeType);
    int Update(AttributeType attributeType);
    int Delete(AttributeType id);
  }
}
