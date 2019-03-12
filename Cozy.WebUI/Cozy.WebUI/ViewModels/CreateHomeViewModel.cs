using Cozy.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cozy.WebUI.ViewModels
{
    public class CreateHomeViewModel
    {
        public Home Home { get; set; }
        public IFormFile Image { get; set; }
    }
}
