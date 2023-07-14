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
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly PostgresContext _dbContext;
        private readonly EntityService _entityService;

        public ApiController(
            ILogger<ApiController> logger,
            PostgresContext dbContext,
            EntityService entityService
        )
        {
            _logger = logger;
            _dbContext = dbContext;
            _entityService = entityService;
        }

        [HttpGet]
        public IEnumerable<Entity> GetAllEntities()
        {
            return _dbContext
                .Set<Entity>()
                .ToArray();
        }

        [HttpGet("{id}")]
        public IEnumerable<Entity> GetEntityById(Guid id)
        {
            return _dbContext
                .Entity
                .Where(cf => cf.Id == id)
                .ToArray();
        }

        [HttpPost]
        public IActionResult CreateEntity(Entity entity)
        {
            try
            {
                if (entity == null || !_entityService.ValidateEntityModel(entity))
                    return BadRequest();

                var newEntity = new Entity
                {
                    TypeId = entity.TypeId,
                    AppId = entity.AppId,
                    Id = new Guid()
                };


                _dbContext.Add<Entity>(newEntity);
                _dbContext.SaveChanges();

                return Ok(entity);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new entity");
            }
        }

        [HttpPatch]
        public IActionResult JsonPatchWithModelState([FromBody] Entity entity)
        {
            if (entity == null
               || !_entityService.ValidateEntityModel(entity)
               || _dbContext.Find<Entity>(entity.Id) == null
           )
                return BadRequest();

            if (entity != null)
            {
                var existingEntity = _dbContext.Find<Entity>(entity.Id);
                existingEntity.AppId = entity.AppId;
                existingEntity.TypeId = entity.TypeId;
                _dbContext.SaveChanges();

                return Ok(existingEntity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteEntity(Guid id)
        {
            var entity = _dbContext.Find<Entity>(id);
            if (entity == null)
                return BadRequest();

            _dbContext.Remove(entity);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
