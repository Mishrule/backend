using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var data = await _groupRepository.GetAll(Endpoints.GroupEndpoint);
            return View(data);

        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupVM groupVm)
        {
            var data = await _groupRepository.Create(Endpoints.GroupEndpoint, groupVm);
            if (data)
            {
                return Json(new {message = "Group Created Successfully"});
            }
            else
            {
                return Json(new
                {
                    message = "Fail to Create Group"
                });

            }

        }
    }
}
