using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{name}")]
        public IEnumerable<CityForecast> GetCityForecast(string name)
        {
            var rnd = new Random();
            return Enumerable.Range(1, 1).Select(index => new CityForecast
            {
                Date = DateTime.Now.AddDays(index),
                Temperature = rnd.Next(-20, 55),
                Name = name,
                Id = Guid.NewGuid()
            })
           .ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<CityForecast>> CreateCityForecast(CityForecast cf)
        {
            try
            {
                if (cf == null)
                    return BadRequest();

                //var createdEmployee = await employeeRepository.AddEmployee(employee);

                return Ok(cf);
                   
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new city forecast record");
            }
        }

        [HttpPatch]
        public IActionResult JsonPatchWithModelState(
    [FromBody] CityForecast cf)
        {
            if (cf != null)
            {
                var cityf = new CityForecast() { Date = DateTime.Now, Temperature = 32, Name = "stp", Id = Guid.NewGuid() };

                if (cf.Date != null)
                {
                    cityf.Date = cf.Date;
                }

                if (cf.Temperature != null)
                {
                    cityf.Temperature = cf.Temperature;
                }

                return new ObjectResult(cityf);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
