using DotnetApi.Models;
using DotnetApi.Interfaces;
using System;
using System.Linq;

namespace DotnetApi.Services
{
  public class AttributeService
  {
    private readonly IAttributeRepository _attributeRepository;

    public AttributeService(IAttributeRepository attributeRepository)
    {
      _attributeRepository = attributeRepository;
    }

    public Guid create(Models.Attribute attribute)
    {
      if (!this.ValidateModel(attribute))
        throw new Exception("Invalid attribute model");

      return _attributeRepository.Create(attribute);
    }

    public Guid update(Models.Attribute attribute)
    {
      if (!this.ValidateModel(attribute))
        throw new Exception("Invalid attribute model");

      Models.Attribute existingAttribute = _attributeRepository.GetById(attribute.Id).First();

      if (existingAttribute == null)
        throw new Exception("Attribute not found");

      return _attributeRepository.Update(attribute);
    }

    public Guid delete(Guid id)
    {
      Models.Attribute existingAttribute = _attributeRepository.GetById(id).First();

      if (existingAttribute == null)
        throw new Exception("Attribute not found");

      return _attributeRepository.Delete(existingAttribute);
    }

    public Models.Attribute[] get(Guid entityId)
    {
      return (Models.Attribute[])_attributeRepository.Get(entityId);
    }

    public Models.Attribute[] getById(Guid id)
    {
      return (Models.Attribute[])_attributeRepository.GetById(id);
    }

    /**
     * @param City appToValidate
     * @return bool - returns false if the model is invalid
     */
    public bool ValidateModel(Models.Attribute attributeToValidate)
    {
      return attributeToValidate != null;
    }
  }
}
