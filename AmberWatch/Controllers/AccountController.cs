using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Data;
using AmberWatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AmberWatch.Controllers
{
    public class AccountController : Controller
    {

        private readonly AmberWatchDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AccountController(IWebHostEnvironment hostingEnvironment,AmberWatchDBContext _context)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = _context;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register(){
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register( AccountModel account){
            if(ModelState.IsValid){
                if(_context.tbl_Account.Any(u=> u.UserName.ToLower() == account.UserName.ToLower())){
                    ModelState.AddModelError("UserName", "Tên đăng nhập đã tồn tại");
                    return View(account);
                }
                _context.tbl_Account.Add(account);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Đăng ký tài khoản thành công!";
                return RedirectToAction("Login");
                
            }
            return View(account);
        }

        [HttpPost("Login")]
        public IActionResult Login (LoginModel account){
            var timeLock = HttpContext.Session.GetString("TimeLock");
            if (!string.IsNullOrEmpty(timeLock) && DateTime.Now < DateTime.Parse(timeLock))
            {
                ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa. Vui lòng thử lại sau 30 phút.");
                return View(account);
            }
            if(ModelState.IsValid){
                var _user = _context.tbl_Account.FirstOrDefault(u => u.UserName.ToLower() == account.UserName.ToLower() && u.PassWord == account.PassWord);
                if (_user == null)
                {
                    var errorLogin = HttpContext.Session.GetInt32("ErrorLogin") ?? 0;
                    errorLogin++;
                    HttpContext.Session.SetInt32("ErrorLogin", errorLogin);
                    if (errorLogin >= 3)
                    {   
                        
                        HttpContext.Session.SetString("TimeLock", DateTime.Now.AddMinutes(30).ToString());
                        ModelState.AddModelError("", "Tài khoản bị khóa do đăng nhập sai quá nhiều lần. Vui lòng thử lại sau 30 phút.");
                        HttpContext.Session.SetString("UserLock", account.UserName);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                    }
                    return View(account);
                }
                HttpContext.Session.SetString("User", account.UserName);
                return RedirectToAction("Index", "Home",new { area = "Customer" });
                
            }
            return View(account);
        }

        [HttpPost("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home",new { area = "Customer" });
        }
    }
}