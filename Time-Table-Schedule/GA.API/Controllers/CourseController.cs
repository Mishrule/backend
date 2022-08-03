using System;
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
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, ILogger<CourseController> logger, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns>List of Courses</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                _logger.LogInformation("Endpoint Initialized");
                var courses = await _courseRepository.GetAll();
                var response = _mapper.Map<IList<CourseDto>>(courses);
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
        /// Gets a Course by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Book record</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourse(int id)
        {
            try
            {
                _logger.LogInformation($" Attempted Call for id: {id}");
                var course = await _courseRepository.GetById(id);
                if (course == null)
                {
                    _logger.LogWarning($"Failed to retrieve record with id: {id}");
                    return NotFound();
                }

                var response = _mapper.Map<CourseDto>(course);
                _logger.LogInformation($"Successfully got record with id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                 _logger.LogInformation($"Error getting record with id: {e.Message}", e);
                 return null;
            }
        }

        /// <summary>
        /// Creates a new Course
        /// </summary>
        /// <param name="bookDTO"></param>
        /// <returns>Book Object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateCourseDto courseDto)
        {
            try
            {
                _logger.LogInformation($"Create Attempted");
                if (courseDto == null)
                {
                    _logger.LogWarning($"Empty Request was submitted");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"Data was Incomplete");
                    return BadRequest(ModelState);
                }

                var courseToCreate = _mapper.Map<Course>(courseDto);
                var isSuccess = await _courseRepository.CreateAsync(courseToCreate);
                if (!isSuccess)
                {
                    _logger.LogError("Course Creating Failed");
                    return StatusCode(500, "Course Creating Failed");
                }

                _logger.LogInformation($"Creation was successful");
                return Created("Create", new {courseToCreate});
            }
            catch (Exception e)
            {
                 
                    _logger.LogError($"{e.Message} - {e.InnerException}");
                return null;
            }
        }

        /// <summary>
        /// Update a Course by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CourseDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, CourseDto courseDto)
        {
            try
            {
                _logger.LogInformation($"Update Attempted on record with id: {id} ");
                if (id < 1 || courseDto == null || id != courseDto.Id)
                {
                    _logger.LogWarning($"Update failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _courseRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var couseToCreate = _mapper.Map<Course>(courseDto);
                var isSuccess = await _courseRepository.UpdateAsync(couseToCreate);
                if (!isSuccess)
                {
                    _logger.LogError($"Update failed for record with id: {id}");
                    return StatusCode(500, "Update failed");
                }
                _logger.LogInformation($"Record with id: {id} successfully updated");
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message} - {e.InnerException}");
                return null;
            }
        }

        /// <summary>
        /// Removes an Course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Delete Attempted on record with id: {id} ");
                if (id < 1)
                {
                    _logger.LogWarning($"Delete failed with bad data - id: {id}");
                    return BadRequest();
                }

                var isExists = await _courseRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"Failed to retrieve record with id: {id}");
                    return NotFound();
                }

                var course = await _courseRepository.GetById(id);
                var isSuccess = await _courseRepository.Delete(course);
                if (!isSuccess)
                {
                    _logger.LogError($"Delete failed for record with id: {id}");
                    return StatusCode(500, "Delete failed");
                }

                _logger.LogInformation($"Record with id: {id} successfully deleted");
                return NoContent();
            }
            catch (Exception e)
            {
               _logger.LogError($" {e.Message} - {e.InnerException}");
               return null;
            }
        }

    }
}
