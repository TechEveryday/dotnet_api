using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

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
        private readonly PostgresContext _dbContext;
        private readonly CityForecastService _cfService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            PostgresContext dbContext,
            CityForecastService cfService
        )
        {
            _logger = logger;
            _dbContext = dbContext;
            _cfService = cfService;
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
                // Do some validation
                if (cf == null || !_cfService.ValidateCityForecastModel(cf))
                    return BadRequest();

                // One example of intereacting with Database directly
                var newCityForecast = new CityForecast
                {
                    Date = cf.Date,
                    Temperature = cf.Temperature,
                    Name = cf.Name,
                    Id = new Guid()
                };


                _dbContext.Add<CityForecast>(newCityForecast);
                _dbContext.SaveChanges();

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
                // Validate that the cf.Id exists in database
                // If its doesnt, return BadRequest();

                // If it does, proceed to make changes to the object
                // Then update row in database with said object
                // Commit changes via _dbContext.SaveChanges();

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

        [HttpDelete]
        public IActionResult DeleteCityForecast(Guid id)
        {
            // Validate that the id exists in database
            // If it doesn't - throw 400 does not exist

            // If it does exist
            // Delete the row in database

            // Return Ok() with the id that we deleted

            // Hint: Your code will HAVE to use _dbContext.[SOME-METHOD] on the id
            // For both finding that the row exists and for deleting it.

            // Hint2: call _dbContext.SaveChanges() to commit the db transaction

            return Ok();
        }
    }
}
