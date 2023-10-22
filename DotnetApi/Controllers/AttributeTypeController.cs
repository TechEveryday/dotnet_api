using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class AttributeTypeController : ControllerBase
  {
    private readonly ILogger<AttributeTypeController> _logger;
    private readonly AttributeTypeService _attributeTypeService;

    public AttributeTypeController(
        ILogger<AttributeTypeController> logger,
        AttributeTypeService attributeTypeService
    )
    {
      _logger = logger;
      _attributeTypeService = attributeTypeService;
    }

    [HttpGet]
    [Route("attributeType/get")]
    public IActionResult GetAttributeTypes()
    {
      return Ok(_attributeTypeService.get());

    }

    [HttpGet]
    [Route("attributeType/getById/{id}")]
    public IActionResult GetAttributeTypeById(int id)
    {
      try
      {
        return Ok(_attributeTypeService.getById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Route("attributeType/create")]
    public IActionResult CreateAttributeType([FromBody] AttributeType attributeType)
    {
      try
      {
        _attributeTypeService.create(attributeType);
        return Ok(attributeType);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error creating new attributeType: {e.Message}");
      }
    }

    [HttpPatch]
    [Route("attributeType/update")]
    public IActionResult PatchAttributeType([FromBody] AttributeType attributeType)
    {
      try
      {
        _attributeTypeService.update(attributeType);
        return Ok(attributeType);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error updating attribute {e.Message}");
      }
    }

    [HttpDelete]
    [Route("attributeType/delete/{id}")]
    public IActionResult DeleteAttributeType(int id)
    {
      try
      {
        _attributeTypeService.delete(id);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
