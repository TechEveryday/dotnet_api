using DotnetApi.Models;
using DotnetApi.Repositories;
using System;
using System.Linq;

namespace DotnetApi.Services
{
  public class AttributeTypeService
  {
    private readonly AttributeTypeRepository _attributeTypeRepository;

    public AttributeTypeService(AttributeTypeRepository attributeTypeRepository)
    {
      _attributeTypeRepository = attributeTypeRepository;
    }

    public int create(AttributeType attributeType)
    {
      if (!this.ValidateModel(attributeType))
        throw new Exception("Invalid AttributeType model");

      return _attributeTypeRepository.Create(attributeType);
    }

    public int update(AttributeType attributeType)
    {
      if (!this.ValidateModel(attributeType))
        throw new Exception("Invalid AttributeType model");

      AttributeType existingAttributeType = _attributeTypeRepository.GetById(attributeType.Id).First();

      if (existingAttributeType == null)
        throw new Exception("AttributeType not found");

      return _attributeTypeRepository.Update(attributeType);
    }

    public int delete(int id)
    {
      AttributeType existingAttributeType = _attributeTypeRepository.GetById(id).First();

      if (existingAttributeType == null)
        throw new Exception("AttributeType not found");

      return _attributeTypeRepository.Delete(existingAttributeType);
    }

    public AttributeType[] get()
    {
      return (AttributeType[])_attributeTypeRepository.Get();
    }

    public AttributeType[] getById(int id)
    {
      return (AttributeType[])_attributeTypeRepository.GetById(id);
    }

    /**
     * @param AttributeType attributeTypeToValidate
     * @return bool - returns false if the model is invalid
     */
    public bool ValidateModel(AttributeType attributeTypeToValidate)
    {
      return attributeTypeToValidate != null
          && attributeTypeToValidate.Id != 0
          && attributeTypeToValidate.Name != null;
    }
  }
}
