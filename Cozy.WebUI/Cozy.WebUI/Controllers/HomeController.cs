using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cozy.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly RoleManager<IdentityRole> _roleManager;

        // Contructor
        public HomeController(IHomeService homeService,
            RoleManager<IdentityRole> roleManager)
        {
            _homeService = homeService;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var home = _homeService.GetById(1);
            return View(home);
        }
    }
}