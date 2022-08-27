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
    public class ProfController : ControllerBase
    {
        private readonly ILogger<ProfController> _logger;
        private readonly IProfRepository _profRepository;
        private readonly IMapper _mapper;
        public ProfDto profDto { get; set; }

        public ProfController(ILogger<ProfController> logger, IProfRepository profRepository, IMapper mapper)
        {
            _logger = logger;
            _profRepository = profRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Get All Profs
        /// </summary>
        /// <returns>A List of Profs</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProfs()
        {
            List<dynamic> Data = new();
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Attempted Call");
                var professors = await _profRepository.GetAll();
                var response = _mapper.Map<IList<ProfDto>>(professors);
                foreach(var dat in response)
                {
                    Data.Add(JsonConvert.DeserializeObject<dynamic>(dat.name));
                }
               // ProfDto data = JsonConvert.DeserializeObject<ProfDto>(response);
                _logger.LogInformation($"{location}: Successful");
                return Ok(Data);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Gets a Prof by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Prof record</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProf(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Attempted Call for id: {id}");
                var prof = await _profRepository.GetById(id);
                if (prof == null)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }

                var response = _mapper.Map<ProfDto>(prof);
                var data = JsonConvert.DeserializeObject<ProfObject>(response.name);
                _logger.LogInformation($"{location}: Successfully got record with id: {id}");
                return Ok(data);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a new Prof
        /// </summary>
        /// <param name="ProfDto"></param>
        /// <returns>Prof Object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(ProfObject profObject)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Create Attempted");
                if (profObject == null)
                {
                    _logger.LogWarning($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }

                var prof = _mapper.Map<Prof>(profDto);
                var isSuccess = await _profRepository.CreateAsync(prof, profObject);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }

                _logger.LogInformation($"{location}: Creation was successful");
                return Created("Create", new { prof = profObject });
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
        /// <param name="profDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, ProfObject profObject)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Update Attempted on record with id: {id} ");
                if (id < 1 || profObject == null)
                {
                    _logger.LogWarning($"{location}: Update failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _profRepository.isExists(id);
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
                var prof = _mapper.Map<Prof>(profDto);
                profObject.prof.id = id;
                var isSuccess = await _profRepository.UpdateAsync(prof, profObject);
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
        /// Removes an Prof by id
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

                var isExists = await _profRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarning($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }

                var prof = await _profRepository.GetById(id);
                var isSuccess = await _profRepository.Delete(prof);
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
