using DotnetApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class AttributeTypeRepository
  {
    private readonly PostgresContext _dbContext;

    public AttributeTypeRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<AttributeType> GetById(int id)
    {
      return _dbContext
        .AttributeType
        .Where(cf => cf.Id == id)
        .ToArray();
    }

    public int Create(AttributeType attributeType)
    {
      _dbContext.Add<AttributeType>(attributeType);
      _dbContext.SaveChanges();

      return attributeType.Id;
    }

    public IEnumerable<AttributeType> Get()
    {
      return _dbContext
        .AttributeType
        .ToArray();
    }

    public int Update(AttributeType attributeType)
    {
      _dbContext
          .AttributeType
          .Update(attributeType);

      _dbContext.SaveChanges();

      return attributeType.Id;
    }

    public int Delete(AttributeType attributeType)
    {
      _dbContext
        .AttributeType
        .Remove(attributeType);

      _dbContext.SaveChanges();

      return attributeType.Id;
    }
  }
}
