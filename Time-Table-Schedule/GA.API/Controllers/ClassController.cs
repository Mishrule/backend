using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GA.API.Contracts;
using GA.API.Data;
using GA.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly ILogger<ClassController> _logger;
        private readonly IMapper _mapper;

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
            try
            {
                _logger.LogInformation("Endpoint Initialized");
                var classes = await _classRepository.GetAll();
                var response = _mapper.Map<IList<ClassDto>>(classes);
                _logger.LogInformation("Endpoint Complete");
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error got @ {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Create Class
        /// </summary>
        /// <param name="classEntity"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(ClassDto entity)
        {
            _logger.LogInformation("Initializing Create Class Endpoint");
            if (entity == null)
            {
                _logger.LogWarning("Empty Class Request was Submitted ");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Class Request was Submitted ");
                return BadRequest(ModelState);
            }

            var createClass = _mapper.Map<Class>(entity);
            var isSuccess = await _classRepository.CreateAsync(createClass);
            if (!isSuccess)
            {
                _logger.LogWarning("Failed to Create Class");
                return StatusCode(500, "Failed to Create Class");
            }
            _logger.LogInformation("Creating was Success and completed");
            return Created("Create", new {createClass});
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
    }
}
