using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Areas.Customer.Models;
using AmberWatch.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmberWatch.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly AmberWatchDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment, AmberWatchDBContext _context)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = _context;
        }

        [HttpGet("Watch")]
        public IActionResult Watch()
        {   
            var watch = _context.tbl_Watch.ToList();
            return PartialView(watch);
        }

        [HttpGet("WatchAutomatic")]
        public IActionResult WatchAutomatic()
        {   
            var watch = _context.tbl_Watch.Where(x => x.collection == "AUTOMATIC").ToList();
            return PartialView(watch);
        }

        [HttpGet("WatchQuartz")]
        public IActionResult WatchQuartz()
        {   
            var watch = _context.tbl_Watch.Where(x => x.collection == "QUARTZ").ToList();
            return PartialView(watch);
        }
        [HttpGet("Customer")]
        public IActionResult Index()
        {
            var model = new HomeModel
            {
                watchModels = _context.tbl_Watch.ToList(),
                watchModelAuto = _context.tbl_Watch.Where(x => x.collection == "AUTOMATIC").ToList(),
                watchModelQuartz = _context.tbl_Watch.Where(x => x.collection == "QUARTZ").ToList()
            };
            return View(model);
        }
    }
}