using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cozy.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        // Contructor
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            var home = _homeService.GetById(1);
            return View(home);
        }
    }
}