using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AmberWatch.Models;
using AmberWatch.Data;
using AmberWatch.Areas.Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace AmberWatch.Controllers;


public class HomeController : Controller
{
    private readonly AmberWatchDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment,AmberWatchDBContext _context)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = _context;
        }

    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home", new { area = "Customer" });
    }

    
}
