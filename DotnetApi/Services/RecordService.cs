using DotnetApi.Models;
using DotnetApi.Interfaces;
using System;
using System.Linq;

namespace DotnetApi.Services
{
  public class RecordService
  {
    private readonly IRecordRepository _recordRepository;

    public RecordService(IRecordRepository recordRepository)
    {
      _recordRepository = recordRepository;
    }

    public int create(Record record)
    {
      if (!this.ValidateModel(record))
        throw new Exception("Invalid record model");

      return _recordRepository.Create(record);
    }

    public int update(Record record)
    {
      if (!this.ValidateModel(record))
        throw new Exception("Invalid record model");

      Record existingRecord = _recordRepository.GetById(record.Id).First();

      if (existingRecord == null)
        throw new Exception("Record not found");

      return _recordRepository.Update(record);
    }

    public int delete(int id)
    {
      Record existingRecord = _recordRepository.GetById(id).First();

      if (existingRecord == null)
        throw new Exception("Record not found");

      return _recordRepository.Delete(existingRecord);
    }

    public Record[] get(Guid entityId)
    {
      return (Record[])_recordRepository.Get(entityId);
    }

    public Record[] getById(int id)
    {
      return (Record[])_recordRepository.GetById(id);
    }

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
