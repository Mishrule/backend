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
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IProcessDataRepository _dataRepository;
        private readonly IMapper _mapper;

        public DataController(ILogger<DataController> logger, IProcessDataRepository dataRepository, IMapper mapper)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns>A List of Data</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetData()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Attempted Call");
                var data = await _dataRepository.GetAll();
                var response = _mapper.Map<IList<ProcessDataDto>>(data);
                _logger.LogInformation($"{location}: Successful");
                return Ok(response);
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
