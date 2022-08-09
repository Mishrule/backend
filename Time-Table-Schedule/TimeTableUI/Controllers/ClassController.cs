using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IGroupRepository _groupRepository;

        public ClassController(IClassRepository classRepository, ILecturerRepository lecturerRepository, ICourseRepository courseRepository, IGroupRepository groupRepository)
        {
            _classRepository = classRepository;
            _lecturerRepository = lecturerRepository;
            _courseRepository = courseRepository;
            _groupRepository = groupRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
           // var data = await _lecturerRepository.GetAll(Endpoints.LecturerEndpoint);
            var lecturerData = await _lecturerRepository.GetAll(Endpoints.LecturerEndpoint);
            var courseData = await _courseRepository.GetAll(Endpoints.CourseEndpoint);
            var groupData = await _groupRepository.GetAll(Endpoints.GroupEndpoint);
            
            ViewBag.lecturer = lecturerData.Select(x => new SelectListItem
                {Value = x.prof.id.ToString(), Text = x.prof.name});

            ViewBag.course = courseData.Select(x => new SelectListItem
                {Value = x.course.id.ToString(), Text = x.course.name});
            
            ViewBag.group = groupData.Select(x => new SelectListItem
                {Value = x.group.id.ToString(), Text = x.group.name});
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassVM classVm)
        {
            var data = await _classRepository.Create(Endpoints.ClassEndpoint, classVm);
            if (data)
            {
                return Json(new {message = "Class Assigned Successfully"});
            }
            else
            {
                return Json(new
                {
                    message = "Fail to Assign Class"
                });

            }

        }
    }
}
