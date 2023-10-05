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
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly PostgresContext _dbContext;
        private readonly AppService _appService;
        private readonly AttributeService _attributeService;
        private readonly AttributeTypeService _attributeTypeService;
        private readonly EntityService _entityService;
        private readonly EntityTypeService _entityTypeService;
        private readonly RecordService _recordService;

        public ApiController(
            ILogger<ApiController> logger,
            PostgresContext dbContext,
            AppService appService,
            AttributeService attributeService,
            AttributeTypeService attributeTypeService,
            EntityService entityService,
            EntityTypeService entityTypeService,
            RecordService recordService
        )
        {
            _logger = logger;
            _dbContext = dbContext;
            _appService = appService;
            _attributeService = attributeService;
            _attributeTypeService = attributeTypeService;
            _entityService = entityService;
            _entityTypeService = entityTypeService;
            _recordService = recordService;
        }

        #region entity
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new entity");
            }
        }

        [HttpPatch]
        [Route("entity/update")]
        public IActionResult PatchEntity([FromBody] Entity entity)
        {
            try
            {
                _entityService.update(entity);
                return Ok(entity);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating entity");
            }
        }

        [HttpDelete]
        [Route("entity/delete/{id}")]
        public IActionResult DeleteEntity(Guid id)
        {
            try
            {
                _entityService.delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region app
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
        #endregion

        #region attribute
        [HttpGet]
        [Route("attribute/getByEntityId/{entityId}")]
        public IActionResult GetAttributes(Guid entityId)
        {
            return Ok(_attributeService.get(entityId));

        }

        [HttpGet]
        [Route("attribute/getById/{id}")]
        public IActionResult GetAttributeById(Guid id)
        {
            try
            {
                return Ok(_attributeService.getById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("attribute/create")]
        public IActionResult CreateAttribute([FromBody] Models.Attribute attribute)
        {
            try
            {
                _attributeService.create(attribute);
                return Ok(attribute);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new attribute");
            }
        }

        [HttpPatch]
        [Route("attribute/update")]
        public IActionResult PatchAttribute([FromBody] Models.Attribute attribute)
        {
            try
            {
                _attributeService.update(attribute);
                return Ok(attribute);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating attribute");
            }
        }

        [HttpDelete]
        [Route("attribute/delete/{id}")]
        public IActionResult DeleteAttribute(Guid id)
        {
            try
            {
                _attributeService.delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region attributeType
        [HttpGet]
        [Route("attributeType/get")]
        public IActionResult GetAttributeTypes()
        {
            return Ok(_attributeTypeService.get());

        }

        [HttpGet]
        [Route("attributeType/getById/{id}")]
        public IActionResult GetAttributeTypeById(int id)
        {
            try
            {
                return Ok(_attributeTypeService.getById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("attributeType/create")]
        public IActionResult CreateAttributeType([FromBody] AttributeType attributeType)
        {
            try
            {
                _attributeTypeService.create(attributeType);
                return Ok(attributeType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new attributeType");
            }
        }

        [HttpPatch]
        [Route("attributeType/update")]
        public IActionResult PatchAttributeType([FromBody] AttributeType attributeType)
        {
            try
            {
                _attributeTypeService.update(attributeType);
                return Ok(attributeType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating attribute");
            }
        }

        [HttpDelete]
        [Route("attributeType/delete/{id}")]
        public IActionResult DeleteAttributeType(int id)
        {
            try
            {
                _attributeTypeService.delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region entityType
        [HttpGet]
        [Route("entityType/get")]
        public IActionResult GetEntityTypes()
        {
            return Ok(_entityTypeService.get());

        }

        [HttpGet]
        [Route("entityType/getById/{id}")]
        public IActionResult GetEntityTypeById(int id)
        {
            try
            {
                return Ok(_entityTypeService.getById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("entityType/create")]
        public IActionResult CreateEntityType([FromBody] EntityType entityType)
        {
            try
            {
                _entityTypeService.create(entityType);
                return Ok(entityType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new entityType");
            }
        }

        [HttpPatch]
        [Route("entityType/update")]
        public IActionResult PatchEntityType([FromBody] EntityType entityType)
        {
            try
            {
                _entityTypeService.update(entityType);
                return Ok(entityType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating entityType");
            }
        }

        [HttpDelete]
        [Route("entityType/delete/{id}")]
        public IActionResult DeleteEntityType(int id)
        {
            try
            {
                _entityTypeService.delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region record
        [HttpGet]
        [Route("record")]
        public IActionResult GetRecords([FromBody] Guid entityId)
        {
            return Ok(_recordService.get(entityId));

        }

        [HttpGet]
        [Route("record/{id}")]
        public IActionResult GetRecordById(int id)
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
        public IActionResult CreateRecord([FromBody] Record record)
        {
            try
            {
                _recordService.create(record);
                return Ok(record);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new record");
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating record");
            }
        }

        [HttpDelete]
        [Route("record/{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                _recordService.delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}
