using DotnetApi.Models;
using DotnetApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Repositories
{
  public class RecordRepository : IRecordRepository
  {
    private readonly PostgresContext _dbContext;

    public RecordRepository(PostgresContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Record> GetById(int id)
    {
      return _dbContext
        .Record
        .Where(cf => cf.Id == id)
        .ToArray();
    }

    public int Create(Record record)
    {
      _dbContext.Add<Record>(record);
      _dbContext.SaveChanges();

      return record.Id;
    }

    public IEnumerable<Record> Get(Guid entityId)
    {
      return _dbContext
        .Record
        .Where(cf => cf.EntityId == entityId)
        .ToArray();
    }

    public int Update(Record record)
    {
      _dbContext
          .Record
          .Update(record);

      _dbContext.SaveChanges();

      return record.Id;
    }

    public int Delete(Record record)
    {
      _dbContext
        .Record
        .Remove(record);

      _dbContext.SaveChanges();

      return record.Id;
    }
  }
}
