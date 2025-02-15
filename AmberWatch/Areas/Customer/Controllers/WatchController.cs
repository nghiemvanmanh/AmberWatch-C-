using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmberWatch.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class WatchController : Controller
    {
        private readonly AmberWatchDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public WatchController(IWebHostEnvironment hostingEnvironment, AmberWatchDBContext _context)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = _context;
        }

        [HttpGet("Watch/Detail/{id}")]
        public IActionResult Detail(int id){
            var watch = _context.tbl_Watch.Find(id);
            if(watch == null){
                return NotFound();
            }
            return View(watch);
        }
    }
}