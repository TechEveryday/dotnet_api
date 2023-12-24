using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class EntityController : ControllerBase
  {
    private readonly ILogger<EntityController> _logger;
    private readonly EntityService _entityService;

    public EntityController(
        ILogger<EntityController> logger,
        EntityService entityService
    )
    {
      _logger = logger;
      _entityService = entityService;
    }

    [HttpGet]
    [Route("entity/getByAppId/{appId}")]
    public IActionResult GetEntitiesByAppId(int appId)
    {
      return Ok(_entityService.get(appId));

    }

    [HttpGet]
    [Route("entity/getById/{id}")]
    public IActionResult GetEntityById(Guid id)
    {
      try
      {
        return Ok(_entityService.getById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Route("entity/create")]
    public IActionResult CreateEntity([FromBody] Entity entity)
    {
      try
      {
        _entityService.create(entity);
        return Ok(entity);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error creating new entity: {e.Message}");
      }
    }

    // [HttpPatch]
    // [Route("entity/update")]
    // public IActionResult PatchEntity([FromBody] Entity entity)
    // {
    //   try
    //   {
    //     _entityService.update(entity);
    //     return Ok(entity);
    //   }
    //   catch (Exception e)
    //   {
    //     return StatusCode(StatusCodes.Status500InternalServerError,
    //         $"Error updating entity: {e.Message}");
    //   }
    // }

    // [HttpDelete]
    // [Route("entity/delete/{id}")]
    // public IActionResult DeleteEntity(Guid id)
    // {
    //   try
    //   {
    //     _entityService.delete(id);
    //     return Ok();
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
  }
}
