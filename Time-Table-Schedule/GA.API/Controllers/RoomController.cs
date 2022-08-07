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
using Newtonsoft.Json;

namespace GA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public RoomDto roomDto { get; set; }
        public RoomController(ILogger<RoomController> logger, IRoomRepository roomRepository, IMapper mapper)
        {
            _logger = logger;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Rooms
        /// </summary>
        /// <returns>A List of Rooms</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRooms()
        {
            List<RoomObject> Data = new();
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Attempted Call");
                var rooms = await _roomRepository.GetAll();
                var response = _mapper.Map<IList<RoomDto>>(rooms);
                foreach (var dat in response)
                {
                    Data.Add(JsonConvert.DeserializeObject<RoomObject>(dat.room));
                }
                _logger.LogInformation($"{location}: Successful");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Gets a Room by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Room record</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoom(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Attempted Call for id: {id}");
                var room = await _roomRepository.GetById(id);
                if (room == null)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<RoomDto>(room);
                var data = JsonConvert.DeserializeObject<RoomDto>(response.room);
                _logger.LogInformation($"{location}: Successfully got record with id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="roomDto"></param>
        /// <returns>Room Object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(RoomObject roomObject)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Create Attempted");
                if (roomObject == null)
                {
                    _logger.LogWarning($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var room = _mapper.Map<Room>(roomDto);
                var isSuccess = await _roomRepository.CreateAsync(room, roomObject);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }
                _logger.LogInformation($"{location}: Creation was successful");
                return Created("Create", new { room = roomObject });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        /// <summary>
        /// Update a Room by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roomDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, RoomObject roomObject)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Update Attempted on record with name: {id} ");
                if (id < 1 || roomObject == null )
                {
                    _logger.LogWarning($"{location}: Update failed with bad data - name: {id}");
                    return BadRequest();
                }
                var isExists = await _roomRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with name: {id}");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var room = _mapper.Map<Room>(roomDto);
                room = new Room
                {
                    id = id
                };
                var isSuccess = await _roomRepository.UpdateAsync(room, roomObject);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Update failed for record with name: {id}");
                }
                _logger.LogInformation($"{location}: Record with name: {id} successfully updated");
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Removes an Room by id
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
                _logger.LogInformation($"{location}: Delete Attempted on record with name: {id} ");
                if (id < 0)
                {
                    _logger.LogWarning($"{location}: Delete failed with bad data - name: {id}");
                    return BadRequest();
                }
                var isExists = await _roomRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var book = await _roomRepository.GetById(id);
                var isSuccess = await _roomRepository.Delete(book);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Delete failed for record with name: {id}");
                }
                _logger.LogInformation($"{location}: Record with id: name: {id} successfully deleted");
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
