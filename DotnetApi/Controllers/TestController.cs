using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
{
  [ApiController]
  public class TestController : ControllerBase
  {
    private readonly ILogger<TestController> _logger;
    private readonly S3Service _s3Service;

    public TestController(
        ILogger<TestController> logger,
        S3Service s3Service
    )
    {
      _logger = logger;
      _s3Service = s3Service;
    }

    // Open question - do I even need this endpoint? Looks like
    // as long as apps know the full URL then it can be accessed
    [HttpGet]
    [Route("test/getObject")]
    public IActionResult GetObject(
      [FromQuery] string bucket,
      [FromQuery] string keyName
    )
    {
      try
      {
        var s3Object = _s3Service.GetObjectInBucket1(bucket, keyName);
        if (!s3Object)
        {
          return StatusCode(StatusCodes.Status500InternalServerError,
              $"Didnt work");
        }
        return Ok(s3Object);
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Didnt work: {e.Message}");
      }
    }

    // [HttpGet]
    // [Route("test/getById/{id}")]
    // public IActionResult GetAppById(int id)
    // {
    //   try
    //   {
    //     return Ok(_s3Service.getById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    [Route("test/create")]
    public IActionResult CreateDelivery()
    {
      try
      {
        _s3Service.CreateTxtFileInBucket1();
        return Ok();
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            $"Didnt work: {e.Message}");
      }
    }
  }
}
