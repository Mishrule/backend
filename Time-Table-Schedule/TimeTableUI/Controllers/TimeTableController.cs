using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTableUI.Contracts;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly IClassRepository _classRepository;
        public TimeTableController(IClassRepository classRepository)
        {

            _classRepository = classRepository;
        }
        public IActionResult Index()
        {
            _classRepository.WriteToJson(Endpoints.WriteToJson);
            return View();
        }
        public  IActionResult Generate()
        {
            _classRepository.GenerateTimeTable(Endpoints.RunAlgorithm);
            return Ok();
        } 
        
    }
}
