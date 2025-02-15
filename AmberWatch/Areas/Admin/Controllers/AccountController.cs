using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Data;
using AmberWatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmberWatch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AmberWatchDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AccountController(IWebHostEnvironment hostingEnvironment, AmberWatchDBContext _context)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = _context;
        }

        //Hiển thị form edit
        [HttpGet("Admin/Account/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var acc = _context.tbl_Account.Find(id);
            if (acc == null)
            {
                return NotFound();
            }
            return View(acc);
        }

         // Cập nhật thông tin sửa
        [HttpPost]
        public async Task<IActionResult> Edit(AccountModel model) {
            if (ModelState.IsValid) {
                _context.Update(model);
                await _context.SaveChangesAsync();
                TempData["SuccessUpdate"] = "Cập nhật thành công!";
                return RedirectToAction("Account","Home");
            }
            return View(model);
        }

        //Xóa người dùng
        [HttpDelete]
        public IActionResult Delete(int id) {
            var acc = _context.tbl_Account.Find(id);
            if (acc != null) {
                _context.tbl_Account.Remove(acc);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}