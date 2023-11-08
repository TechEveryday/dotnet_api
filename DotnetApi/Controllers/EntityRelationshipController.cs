using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class EntityRelationshipController : ControllerBase
  {
    private readonly ILogger<EntityRelationshipController> _logger;
    private readonly EntityRelationshipService _entityRelationshipService;

    public EntityRelationshipController(
        ILogger<EntityRelationshipController> logger,
        EntityRelationshipService entityRelationshipService
    )
    {
      _logger = logger;
      _entityRelationshipService = entityRelationshipService;
    }

    [HttpGet]
    [Route("entityRelationship/get/{entityId}")]
    public IActionResult GetRelationshipsForEntity(Guid entityId)
    {
      return Ok(_entityRelationshipService.get(entityId));

    }

    [HttpPost]
    [Route("entityRelationship/create")]
    public IActionResult CreateEntityRelationship([FromBody] EntityRelationship entityRelationship)
    {
      try
      {
        _entityRelationshipService.create(entityRelationship);
        return Ok(entityRelationship);
      }
      catch (Exception e)
      {
        var errMessage = $"Error creating new entityRelationship: {e.Message}";
        _logger.LogError(errMessage);
        return StatusCode(StatusCodes.Status500InternalServerError, errMessage
            );
      }
    }
  }
}
