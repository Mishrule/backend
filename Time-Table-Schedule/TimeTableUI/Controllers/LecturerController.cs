using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Services;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class LecturerController : Controller
    {
        public ILecturerRepository LecturerRepository { get; }

        public LecturerController(ILecturerRepository lecturerRepository)
        {
            LecturerRepository = lecturerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var data = await LecturerRepository.GetAll(Endpoints.LecturerEndpoint);
            return View(data);

        }

        [HttpPost]
        public async Task<IActionResult> Create(RootLecturerVM lecturer)
        {
            var data = await LecturerRepository.Create(Endpoints.LecturerEndpoint, lecturer);
            if (data)
            {
                return Json(new {message = "Lecturer Created Successfully"});
            }
            else
            {
                return Json(new
                {
                    message = "Fail to Create Lecturer"
                });

            }

        }

    }
}





