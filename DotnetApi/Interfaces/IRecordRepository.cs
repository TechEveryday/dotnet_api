using DotnetApi.Models;
using System;
using System.Collections.Generic;

namespace DotnetApi.Interfaces
{
  public interface IRecordRepository
  {
    IEnumerable<Record> Get(Guid entityId);
    IEnumerable<Record> GetById(int id);
    int Create(Record record);
    int Update(Record record);
    int Delete(Record id);
  }
}
