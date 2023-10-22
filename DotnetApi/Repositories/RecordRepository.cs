using DotnetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetApi.Repositories
{
  public class RecordRepository
  {
    private readonly PostgresContext _dbContext;

    public RecordRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    // public IEnumerable<Record> GetById(int id)
    // {
    //   return _dbContext
    //     .Record
    //     .Where(cf => cf.Id == id)
    //     .ToArray();
    // }

    public IEnumerable<Record> GetByEntityAndAttribute(Guid entityId, Guid attributeId)
    {
      return _dbContext
        .Record
        .Where(cf => cf.EntityId == entityId && cf.AttributeId == attributeId)
        .ToArray();
    }

    public Record Create(Record record)
    {
      _dbContext.Add<Record>(record);
      _dbContext.SaveChanges();

      return record;
    }

    public IEnumerable<Record> Get(Guid entityId)
    {
      return _dbContext
        .Record
        .Where(cf => cf.EntityId == entityId)
        .ToArray();
    }

    public Record Update(Record record)
    {
      _dbContext
          .Record
          .Update(record);

      _dbContext.SaveChanges();

      return record;
    }

    // public int Delete(Record record)
    // {
    //   _dbContext
    //     .Record
    //     .Remove(record);

    //   _dbContext.SaveChanges();

    //   return record.Id;
    // }
  }
}
