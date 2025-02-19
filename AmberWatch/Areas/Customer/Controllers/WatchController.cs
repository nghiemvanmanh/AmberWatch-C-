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

        [HttpGet("Watch/All")]
        public IActionResult All(){
            var watch = _context.tbl_Watch.ToList();
            return View(watch);
        }
        [HttpGet("Watch/AutomaticAll")]
        public IActionResult AutomaticAll(){
            var watchModelAuto = _context.tbl_Watch.Where(x => x.collection == "AUTOMATIC").ToList();
            return View(watchModelAuto);
                
        }
        [HttpGet("Watch/QuartzAll")]
        public IActionResult QuartzAll(){
            var watchModelQuartz = _context.tbl_Watch.Where(x => x.collection == "QUARTZ").ToList();
            return View(watchModelQuartz);
        }

        [HttpGet("Watch/Male")]
        public IActionResult Male(){
            var watch = _context.tbl_Watch.Where(x => x.sex == "Nam").ToList();
            return View(watch);
        }

        [HttpGet("Watch/Female")]
        public IActionResult Female(){
            var watch = _context.tbl_Watch.Where(x => x.sex == "Nữ").ToList();
            return View(watch);
        }

        [HttpGet("Watch/Casio")]
        public IActionResult Casio(){
            var watch = _context.tbl_Watch.Where(x => x.model == "Casio").ToList();
            return View(watch);
        }

        [HttpGet("Watch/Citizen")]
        public IActionResult Citizen(){
            var watch = _context.tbl_Watch.Where(x => x.model == "Citizen").ToList();
            return View(watch);
        }

        [HttpGet("Watch/Orient")]
        public IActionResult Orient(){
            var watch = _context.tbl_Watch.Where(x => x.model == "Orient").ToList();
            return View(watch);
        }

        [HttpGet("Watch/PierreLannier")]
        public IActionResult PierreLannier(){
            var watch = _context.tbl_Watch.Where(x => x.model == "Pierre Lannier").ToList();
            return View(watch);
        }

        [HttpGet("Watch/Seiko")]
        public IActionResult Seiko(){
            var watch = _context.tbl_Watch.Where(x => x.model == "Seiko").ToList();
            return View(watch);
        }

        
    }
}