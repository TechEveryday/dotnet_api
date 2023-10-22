using DotnetApi.Models;
using DotnetApi.Repositories;
using System;
using System.Linq;

namespace DotnetApi.Services
{
  public class RecordService
  {
    private readonly RecordRepository _recordRepository;

    public RecordService(RecordRepository recordRepository)
    {
      _recordRepository = recordRepository;
    }

    public Record create(Record record)
    {
      if (!this.ValidateModel(record))
        throw new Exception("Invalid record model");

      return _recordRepository.Create(record);
    }

    public Record update(Record record)
    {
      if (!this.ValidateModel(record))
        throw new Exception("Invalid record model");

      Record existingRecord = _recordRepository.GetByEntityAndAttribute(record.EntityId, record.AttributeId).First();

      if (existingRecord == null)
        throw new Exception("Record not found");

      return _recordRepository.Update(record);
    }

    // public int delete(int id)
    // {
    //   Record existingRecord = _recordRepository.GetById(id).First();

    //   if (existingRecord == null)
    //     throw new Exception("Record not found");

    //   return _recordRepository.Delete(existingRecord);
    // }

    public Record[] get(Guid entityId)
    {
      return (Record[])_recordRepository.Get(entityId);
    }

    // public Record[] getById(int id)
    // {
    //   return (Record[])_recordRepository.GetById(id);
    // }

    // public Record[] getByEntityAndAttribute(Guid entityId, Guid attributeId)
    // {
    //   return (Record[])_recordRepository.GetByEntityAndAttribute(entityId, attributeId);
    // }

    /**
     * @param City appToValidate
     * @return bool - returns false if the model is invalid
     */
    public bool ValidateModel(Record recordToValidate)
    {
      return recordToValidate != null;
    }
  }
}
