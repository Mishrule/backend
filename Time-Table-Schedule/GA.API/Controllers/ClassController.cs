using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GA.API.Contracts;
using GA.API.Data;
using GA.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly ILogger<ClassController> _logger;
        private readonly IMapper _mapper;
        public ClassDto classDto { get; set; }

        public ClassController(IClassRepository classRepository, ILogger<ClassController> logger, IMapper mapper)
        {
            _classRepository = classRepository;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all Classes
        /// </summary>
        /// <returns>List of Classes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetClasses()
        {
            List<ClassObject> Data = new();
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation("Endpoint Initialized");
                var classes = await _classRepository.GetAll();

                var response = _mapper.Map<IList<ClassDto>>(classes);
                foreach (var dat in response)
                {
                    Data.Add(JsonConvert.DeserializeObject<ClassObject>(dat.@class));
                }
                _logger.LogInformation("Endpoint Complete");
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error got @ {e.Message}");
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Create Class
        /// </summary>
        /// <param name="classEntity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(ClassObject classObject)
        {
            _logger.LogInformation("Initializing Create Class Endpoint");
            if (classObject == null)
            {
                _logger.LogWarning("Empty Class Request was Submitted ");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Class Request was Submitted ");
                return BadRequest(ModelState);
            }

            //var numbers = entity.Groups;
            //List<string> strings = numbers.ConvertAll<string>(x => x.ToString());

            //entity.Group = String.Join(", ", strings);



            var createClass = _mapper.Map<Class>(classDto);
            var isSuccess = await _classRepository.CreateAsync(createClass, classObject);
            if (!isSuccess)
            {
                _logger.LogWarning("Failed to Create Class");
                return StatusCode(500, "Failed to Create Class");
            }
            _logger.LogInformation("Creating was Success and completed");
            return Created("Create", new { @class = classObject });
        }

        /*
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Initializing Delete Class Endpoint");
            if (id <= 0)
            {
                _logger.LogWarning("Invalid Class Id was Submitted ");
                return BadRequest(ModelState);
            }
            var classToDelete = await _classRepository.GetById(id);
            if (classToDelete == null)
            {
                _logger.LogWarning("Class Not Found");
                return NotFound();
            }
            var isSuccess = await _classRepository.Delete(classToDelete);
            if (!isSuccess)
            {
                _logger.LogWarning("Failed to Delete Class");
                return StatusCode(500, "Failed to Delete Class");
            }
            _logger.LogInformation("Deleting was Success and completed");
            return NoContent();
        }
        */
        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
    }
}
