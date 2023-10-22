using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class RecordController : ControllerBase
  {
    private readonly ILogger<RecordController> _logger;
    private readonly RecordService _recordService;

    public RecordController(
        ILogger<RecordController> logger,
        RecordService recordService
    )
    {
      _logger = logger;
      _recordService = recordService;
    }

    [HttpGet]
    [Route("record")]
    public IActionResult GetRecords([FromBody] Guid entityId)
    {
      return Ok(_recordService.get(entityId));

    }

    // [HttpGet]
    // [Route("record/{id}")]
    // public IActionResult GetRecordByEntityIdAndAttributeId(Guid entityId, Guid attributeId)
    // {
    //   try
    //   {
    //     return Ok(_recordService.getByEntityAndAttribute(entityId, attributeId));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    [Route("record")]
    public IActionResult CreateRecord([FromBody] Record record)
    {
      try
      {
        _recordService.create(record);
        return Ok(record);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error creating new record: {e.Message}");
      }
    }

    [HttpPatch]
    [Route("record")]
    public IActionResult PatchRecord([FromBody] Record record)
    {
      try
      {
        _recordService.update(record);
        return Ok(record);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error updating record: {e.Message}");
      }
    }

    // [HttpDelete]
    // [Route("record/{id}")]
    // public IActionResult DeleteRecord(int id)
    // {
    //   try
    //   {
    //     _recordService.delete(id);
    //     return Ok();
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
  }
}
