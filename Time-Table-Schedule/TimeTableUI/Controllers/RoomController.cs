using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class RoomController : Controller
    {
        public IRoomRepository RoomRepository { get; }

        public RoomController(IRoomRepository roomRepository)
        {
            RoomRepository = roomRepository;
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
        public async Task<IActionResult> Create(RoomVM room)
        {
            var data = await RoomRepository.Create(Endpoints.RoomEndpoint, room);
            if (data)
            {
                return Json(new {message = "Room Created Successfully" });
            }
            else
            {
                return Json(new
                {
                    message = "Fail to Create Room"
                });

            }

        }
    }
}