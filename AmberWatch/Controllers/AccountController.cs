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

        public AccountController(AmberWatchDBContext _context){
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
                TempData["SuccessMessage"] = "Đăng ký tài khoản thành công! Bạn sẽ được chuyển hướng đến trang đăng nhập trong giây lát.";
                
            }
            return View(account);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login (AccountModel account){
            if(ModelState.IsValid){
                var acc = await _context.tbl_Account.FirstOrDefaultAsync(a => a.UserName.ToLower() == account.UserName.ToLower() && a.PassWord.ToLower() == account.PassWord.ToLower());
                if(acc == null){
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
                    return View(account);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }
    }
}