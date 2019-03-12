using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Cozy.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Cozy.WebUI.Controllers
{
    [Authorize(Roles = "Landlord")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _environment;

        // Contructor
        public HomeController(IHomeService homeService,
            UserManager<AppUser> userManager,
            IHostingEnvironment environment)
        {
            _homeService = homeService;
            _userManager = userManager;
            _environment = environment;
        }

        public IActionResult List()
        {
            var landlordId = _userManager.GetUserId(User);

            var homes = _homeService.GetByLandlordId(landlordId);

            return View(homes); // ICollection<Home>
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateHomeViewModel vm)
        {
            Home newHome = vm.Home;
            IFormFile image = vm.Image;

            // upload image
            if(image != null && image.Length > 0)
            {
                // _environment.WebRootPath --> ~/wwwroot/images/homes
                string storageFolder = Path.Combine(_environment.WebRootPath,"images/homes");
                
                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                // ~/wwwroot/images/home/00-012sd-fsdf.jpg
                string fullPath = Path.Combine(storageFolder, newImageName);

                using(var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // append new image location to newHome
                newHome.ImageURL = $"/images/homes/{newImageName}";
            }

            newHome.LandLordId = _userManager.GetUserId(User);

            // save newHome
            _homeService.Create(newHome);


            return RedirectToAction("List");
        }

    }
}