using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmberWatch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [HttpGet("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}