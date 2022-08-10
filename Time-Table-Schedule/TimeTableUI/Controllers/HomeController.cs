using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeTableUI.Contracts;
using TimeTableUI.Models;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IRoomRepository RoomRepository { get; }
        public HomeController(ILogger<HomeController> logger, IRoomRepository roomRepository)
        {
            _logger = logger;
            RoomRepository = roomRepository;
        }

        public async Task<IActionResult> Index()
        {
           // var data = await RoomRepository.GetAll(Endpoints.RoomEndpoint);
            //ViewBag.room = data.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
