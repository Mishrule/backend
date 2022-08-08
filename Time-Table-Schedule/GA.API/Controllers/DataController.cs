using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using GA.API.Contracts;
using GA.API.Data;
using GA.API.DTOs;
using GaSchedule;
using GaSchedule.Algorithm;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IProcessDataRepository _dataRepository;
        private readonly IMapper _mapper;

        private readonly IWebHostEnvironment _env;

        public DataController(ILogger<DataController> logger, IProcessDataRepository dataRepository, IMapper mapper,
            IWebHostEnvironment env)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _mapper = mapper;
            _env = env;
        }

        /// <summary>
        /// Get All Data
        /// </summary>
        /// <returns>A List of Data</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDatum()
        {
            var location = GetControllerActionNames();
            List<dynamic> Data = new();
            //IDictionary<string, object> ss ;
            try
            {
                _logger.LogInformation($"{location}: Attempted Call");
                var data = await _dataRepository.GetAll();
                var response = _mapper.Map<IList<GetDataDto>>(data);
                //foreach (var item in response)
                //{
                //    //  var aa = JsonConvert.DeserializeObject(item.data);
                //    // Data.Add(JsonConvert.DeserializeObject<DataClass>(item.data));
                //   // Data.Add(JsonConvert.DeserializeObject<dynamic>(item.prof.prof));
                //}
                _logger.LogInformation($"{location}: Successful");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        [HttpGet("GetJsonData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJsonData()
        {

            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Attempted Call");
                var json = await _dataRepository.GetFileToJson();
                var response = _mapper.Map<IList<GetDataDto>>(json);

                _logger.LogInformation($"{location}: Successful");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        [HttpGet("GetData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetData()
        {
            List<dynamic> Data = new();
            // List<dynamic> d = new();

            //List<DataDto> dataResponse = new List<DataDto>();
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Attempted Call");
                var json = await _dataRepository.GetData();
                var response = _mapper.Map<IList<DataDto>>(json);

                foreach (var item in response)
                {
                    //  var aa = JsonConvert.DeserializeObject(item.data);
                    // Data.Add(JsonConvert.DeserializeObject<DataClass>(item.data));
                    var dd = JsonConvert.DeserializeObject<dynamic>(item.data);
                    Data.Add(dd);

                    // dynamic dynamicObject = JsonConvert.DeserializeObject<ExpandoObject>(item.data);

                }

                //  JsonConvert.SerializeObject(response);
                //for (int i = 0; i < Data.Count; i++)
                //{
                //    var dd = JsonConvert.DeserializeObject<dynamic>(Data[i]);
                //}

                _logger.LogInformation($"{location}: Successful");
                // return Ok(JsonConvert.SerializeObject(response));
                return Ok(Data);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        /// <summary>
        /// Creates a new Group
        /// </summary>
        /// <param name="CreateData"></param>
        /// <returns>Group Object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateProcessDataDto createDataDto)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInformation($"{location}: Create Attempted");
                if (createDataDto == null)
                {
                    _logger.LogWarning($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }

                var data = _mapper.Map<ProcessData>(createDataDto);
                var isSuccess = await _dataRepository.CreateAsync(data);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }

                _logger.LogInformation($"{location}: Creation was successful");
                return Created("Create", new {data = data});
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }



        [HttpGet("RunAlgorithm")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void RunAlgorithm()
        {
            CallingEndpoint.GetData();
            Stopwatch stopwatch = Stopwatch.StartNew();

            var FILE_NAME =  "GaSchedule.json";
            var configuration = new GaSchedule.Algorithm.Configuration();
            configuration.ParseFile(FILE_NAME);

            // var alg = new GeneticAlgorithm<Schedule>(new Schedule(configuration));
            var alg = new Amga2<Schedule>(new Schedule(configuration));

            System.Console.WriteLine("GA Schedule Version {0} C# .NET Core. Making a Class Schedule Using {1}.",
                Assembly.GetExecutingAssembly().GetName().Version, alg.ToString());
            System.Console.WriteLine(".......");

            alg.Run();
            var htmlResult = HtmlOutput.GetResult(alg.Result);

            var tempFilePath = Path.GetTempPath() + FILE_NAME.Replace(".json", ".htm");
            using (StreamWriter outputFile = new StreamWriter(tempFilePath))
            {
                outputFile.WriteLine(htmlResult);
            }

            System.Console.WriteLine("");
            System.Console.WriteLine(@"Completed in {0:s\.fff} secs with peak memory usage of {1}.", stopwatch.Elapsed,
                Process.GetCurrentProcess().PeakWorkingSet64.ToString("#,#"));

            using (var proc = new Process())
            {
                proc.StartInfo.FileName = tempFilePath;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "open";
                proc.Start();
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
