using DotnetApi.Models;
using DotnetApi.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Services
{
  public class RecordService
  {
    private readonly RecordRepository _recordRepository;
    private readonly EntityRepository _entityRepository;
    private readonly AttributeRepository _attributeRepository;
    private readonly S3Service _s3Service;

    public RecordService(
      RecordRepository recordRepository,
      EntityRepository entityRepository,
      AttributeRepository attributeRepository,
      S3Service s3Service
    )
    {
      _recordRepository = recordRepository;
      _entityRepository = entityRepository;
      _attributeRepository = attributeRepository;
      _s3Service = s3Service;
    }

    public async Task<Record> create(Record record)
    {
      if (!this.ValidateModel(record))
        throw new Exception("Invalid record model");

      // If the record is a photo, upload it to S3 and replace the value with the S3 bucket URL
      Entity existingEntity = _entityRepository.GetById(record.EntityId).First();
      Models.Attribute existingAttribute = _attributeRepository.GetById(record.AttributeId).First();
      if (existingEntity != null
        && existingEntity.TypeId == 4 // Package
        && existingAttribute != null
        && existingAttribute.TypeId == 19 // photo_bytes
      )
      {
        var s3BucketUrl = await _s3Service.WritingAnObject(record.EntityId, record.Value);
        record.Value = s3BucketUrl;
      }

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

    public Record[] getById(Guid id)
    {
      return (Record[])_recordRepository.GetById(id);
    }

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
