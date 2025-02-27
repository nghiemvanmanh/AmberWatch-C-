using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Areas.Customer.Models;
using AmberWatch.Data;
using AmberWatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AmberWatch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AmberWatchDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment, AmberWatchDBContext _context)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = _context;
        }
        [HttpGet("Admin")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("KeyAdmin") == null)
            {
                return RedirectToAction("Login", "Home");
            }else{
                return View();    
            }      
        }   

        [HttpGet("Admin/Login")]
        public IActionResult Login(){
            return View();
        }
        [HttpPost("Admin/Login")]
        public IActionResult Login(AccountModel account)
        {
            if(!ModelState.IsValid){
                if(account.UserName == "admin" && account.PassWord == "2003"){
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = "Sai tài khoản hoặc mật khẩu!";
                HttpContext.Session.SetString("KeyAdmin", account.UserName);
                return View();
            }
            return View();
        }

        [HttpGet("Admin/Account")]
        public IActionResult Account(){
            var acc = _context.tbl_Account.ToList();
            return View(acc);
        }

        [HttpGet("Admin/Watch")]
        public IActionResult Watch(){
            var acc = _context.tbl_Watch.ToList();
            return View(acc);
        }

        [HttpGet("Admin/Post")]
        public IActionResult Post(){
            return View();
        }
        [HttpPost("Admin/Post")]
        public IActionResult Post(WatchModel watch, IFormFile imageFile){
            if (!ModelState.IsValid)
            {

                if (imageFile != null && imageFile.Length > 0)
                {
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            Console.WriteLine("Model Error: " + error.ErrorMessage);
                            Console.WriteLine("Model Error: " + imageFile.Length);
                            Console.WriteLine("Model Error: " + Guid.NewGuid().ToString() + "_" + imageFile.FileName);
                        }
                    }
                    return View(watch);
                }

            }
            if (ModelState.IsValid)
            {
                // car.Poster = HttpContext.Session.GetString("FullName");
                // car.SDT = HttpContext.Session.GetString("SDT");

                if (imageFile != null && imageFile.Length > 0)
                {
                    // Lấy đường dẫn thư mục wwwroot/image
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/watch");

                    // Tạo tên file duy nhất để tránh trùng lặp
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Lưu file vào thư mục
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyToAsync(fileStream);
                    }
                    watch.img = "/images/watch/" + uniqueFileName;
                    Console.WriteLine("Url Image : " + watch.img);
                }
                Console.WriteLine("Url img : " + watch.img);
                // Thêm car vào cơ sở dữ liệu
                _context.tbl_Watch.Add(watch);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(watch);
        }
    }
}