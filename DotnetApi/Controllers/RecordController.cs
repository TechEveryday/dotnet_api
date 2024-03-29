using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;
using System.Threading.Tasks;

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
    [Route("record/getByEntityId/{entityId}")]
    public IActionResult GetRecords(Guid entityId)
    {
      return Ok(_recordService.get(entityId));

    }

    [HttpGet]
    [Route("record/{id}")]
    public IActionResult GetRecordById(Guid id)
    {
      try
      {
        return Ok(_recordService.getById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Route("record")]
    public async Task<Record> CreateRecord([FromBody] Record record)
    {
      try
      {
        return await _recordService.create(record);
        // return Ok(record);
      }
      catch (Exception e)
      {
        Console.WriteLine($"Error creating new record: {e.Message}");
        return null;
        // return StatusCode(StatusCodes.Status500InternalServerError,
        // $"Error creating new record: {e.Message}");
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
