using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Services;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseVM course)
        {
            var data = await _courseRepository.Create(Endpoints.CourseEndpoint, course);
            if (data)
            {
                return Json(new {message = "Course Created Successfully"});
            }
            else
            {
                return Json(new
                {
                    message = "Fail to Create Course"
                });

            }

        }
    }
}
