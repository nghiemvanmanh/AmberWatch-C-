using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AmberWatch.Models;

namespace AmberWatch.Controllers;


public class HomeController : Controller
{

    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home", new { area = "Customer" });
    }
}
