using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GA.API.Contracts;
using GA.API.Data;
using GA.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.Logging;

namespace GA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ILogger<GroupController> _logger;
        private readonly IMapper _mapper;

        public GroupController(IGroupRepository groupRepository, ILogger<GroupController> logger, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all Groups
        /// </summary>
        /// <returns>List of Groups</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetGroups()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Endpoint Initialized");
                var groups = await _groupRepository.GetAll();
                var response = _mapper.Map<IList<GroupDto>>(groups);
                _logger.LogInformation($"{location}: Endpoint Complete");
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"{location}: Error got @ {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets a Group by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Group record</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroup(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                _logger.LogInformation($"{location}: Attempted Call for id: {id}");
                var group = await _groupRepository.GetById(id);
                if (group == null)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }

                var response = _mapper.Map<GroupDto>(group);
                _logger.LogInformation($"{location}: Successfully got record with id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a new Group
        /// </summary>
        /// <param name="groupDTO"></param>
        /// <returns>Group Object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(GroupDto groupDto)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Create Attempted");
                if (groupDto == null)
                {
                    _logger.LogWarning($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var group = _mapper.Map<Group>(groupDto);
                var isSuccess = await _groupRepository.CreateAsync(group);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }
                _logger.LogInformation($"{location}: Creation was successful");
                return Created("Create", new {book = group });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        /// <summary>
        /// Update a Book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, GroupDto groupDto)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Update Attempted on record with id: {id} ");
                if (id < 1 || groupDto == null || id != groupDto.Id)
                {
                    _logger.LogWarning($"{location}: Update failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _groupRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var book = _mapper.Map<Group>(groupDto);
                var isSuccess = await _groupRepository.UpdateAsync(book);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Update failed for record with id: {id}");
                }
                _logger.LogInformation($"{location}: Record with id: {id} successfully updated");
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Removes an Remove by id
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
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Delete Attempted on record with id: {id} ");
                if (id < 1)
                {
                    _logger.LogWarning($"{location}: Delete failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _groupRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var book = await _groupRepository.GetById(id);
                var isSuccess = await _groupRepository.Delete(book);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Delete failed for record with id: {id}");
                }
                _logger.LogInformation($"{location}: Record with id: {id} successfully deleted");
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }


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
