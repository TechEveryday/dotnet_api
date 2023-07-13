using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetApi.Models;
using DotnetApi.Services;

namespace DotnetApi.Controllers
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
            return _dbContext
                .Set<WeatherForecast>()
                .ToArray();
        }

        [HttpGet("{name}")]
        public IEnumerable<CityForecast> GetCityForecast(string name)
        {
            return _dbContext
                .CityForecast
                .Where(cf => cf.Name == name)
                .ToArray();
        }

        [HttpPost]
        public IActionResult CreateCityForecast(CityForecast cf)
        {
            try
            {
                if (cf == null || !_cfService.ValidateCityForecastModel(cf))
                    return BadRequest();

                var newCityForecast = new CityForecast
                {
                    Date = cf.Date,
                    Temperature = cf.Temperature,
                    Name = cf.Name,
                    Id = new Guid()
                };


                _dbContext.Add<CityForecast>(newCityForecast);
                _dbContext.SaveChanges();

                return Ok(cf);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new city forecast record");
            }
        }

        [HttpPatch]
        public IActionResult JsonPatchWithModelState([FromBody] CityForecast cf)
        {
            if (cf != null)
            {
                if (cf == null
                    || !_cfService.ValidateCityForecastModel(cf)
                    || _dbContext.Find<CityForecast>(cf.Id) == null)
                    return BadRequest();

                var cityf = _dbContext.Find<CityForecast>(cf.Id);
                cityf.Date = cf.Date;
                cityf.Name = cf.Name;
                cityf.Temperature = cf.Temperature;
                _dbContext.SaveChanges();

                return Ok(cityf);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteCityForecast(Guid id)
        {
            var cf = _dbContext.Find<CityForecast>(id);
            if (cf == null)
                return BadRequest();

            _dbContext.Remove(cf);
            _dbContext.SaveChanges();

            return Ok(cf);
        }
    }
}
