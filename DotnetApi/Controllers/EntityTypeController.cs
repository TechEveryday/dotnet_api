using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class EntityTypeController : ControllerBase
  {
    private readonly ILogger<EntityTypeController> _logger;
    private readonly EntityTypeService _entityTypeService;

    public EntityTypeController(
        ILogger<EntityTypeController> logger,
        EntityTypeService entityTypeService
    )
    {
      _logger = logger;
      _entityTypeService = entityTypeService;
    }

    [HttpGet]
    [Route("entityType/get")]
    public IActionResult GetEntityTypes()
    {
      return Ok(_entityTypeService.get());

    }

    [HttpGet]
    [Route("entityType/getById/{id}")]
    public IActionResult GetEntityTypeById(int id)
    {
      try
      {
        return Ok(_entityTypeService.getById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Route("entityType/create")]
    public IActionResult CreateEntityType([FromBody] EntityType entityType)
    {
      try
      {
        _entityTypeService.create(entityType);
        return Ok(entityType);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error creating new entityType: {e.Message}");
      }
    }

    [HttpPatch]
    [Route("entityType/update")]
    public IActionResult PatchEntityType([FromBody] EntityType entityType)
    {
      try
      {
        _entityTypeService.update(entityType);
        return Ok(entityType);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error updating entityType: {e.Message}");
      }
    }

    // [HttpDelete]
    // [Route("entityType/delete/{id}")]
    // public IActionResult DeleteEntityType(int id)
    // {
    //   try
    //   {
    //     _entityTypeService.delete(id);
    //     return Ok();
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
  }
}
