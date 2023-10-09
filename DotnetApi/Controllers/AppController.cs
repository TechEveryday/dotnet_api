using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class AppController : ControllerBase
  {
    private readonly ILogger<AppController> _logger;
    private readonly AppService _appService;

    public AppController(
        ILogger<AppController> logger,
        AppService appService
    )
    {
      _logger = logger;
      _appService = appService;
    }

    [HttpGet]
    [Route("app/get")]
    public IActionResult GetApps()
    {
      return Ok(_appService.get());
    }

    [HttpGet]
    [Route("app/getById/{id}")]
    public IActionResult GetAppById(int id)
    {
      try
      {
        return Ok(_appService.getById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Route("app/create")]
    public IActionResult CreateApp([FromBody] App app)
    {
      try
      {
        _appService.create(app);
        return Ok(app);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Error creating new app");
      }
    }

    [HttpPatch]
    [Route("app/update")]
    public IActionResult PatchApp([FromBody] App app)
    {
      try
      {
        _appService.update(app);
        return Ok(app);
      }
      catch
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Error updating app");
      }
    }

    [HttpDelete]
    [Route("app/delete/{id}")]
    public IActionResult DeleteApp(int id)
    {
      try
      {
        _appService.delete(id);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
