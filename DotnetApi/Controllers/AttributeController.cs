using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class AttributeController : ControllerBase
  {
    private readonly ILogger<AttributeController> _logger;
    private readonly AttributeService _attributeService;

    public AttributeController(
        ILogger<AttributeController> logger,
        AttributeService attributeService
    )
    {
      _logger = logger;
      _attributeService = attributeService;
    }

    [HttpGet]
    [Route("attribute/getByEntityId/{entityId}")]
    public IActionResult GetAttributes(Guid entityId)
    {
      return Ok(_attributeService.get(entityId));

    }

    [HttpGet]
    [Route("attribute/getById/{id}")]
    public IActionResult GetAttributeById(Guid id)
    {
      try
      {
        return Ok(_attributeService.getById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Route("attribute/create")]
    public IActionResult CreateAttribute([FromBody] Models.Attribute attribute)
    {
      try
      {
        _attributeService.create(attribute);
        return Ok(attribute);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error creating new attribute: {e.Message}");
      }
    }

    [HttpPatch]
    [Route("attribute/update")]
    public IActionResult PatchAttribute([FromBody] Models.Attribute attribute)
    {
      try
      {
        _attributeService.update(attribute);
        return Ok(attribute);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error updating attribute: {e.Message}");
      }
    }

    [HttpDelete]
    [Route("attribute/delete/{id}")]
    public IActionResult DeleteAttribute(Guid id)
    {
      try
      {
        _attributeService.delete(id);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
