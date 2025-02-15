using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Areas.Customer.Models;
using AmberWatch.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmberWatch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WatchController : Controller
    {
        private readonly AmberWatchDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public WatchController(IWebHostEnvironment hostingEnvironment, AmberWatchDBContext _context)
        {
            _hostingEnvironment = hostingEnvironment;
            this._context = _context;
        }
        // Hiển thị form chỉnh sửa
        [HttpGet("Admin/Watch/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var watch = _context.tbl_Watch.FirstOrDefault(w => w.id_watch == id);
            if (watch == null)
            {
                return NotFound();
            }
            return View(watch);
        }

        [HttpPost]
        public IActionResult Edit(WatchModel watch){
            if (ModelState.IsValid) {
                _context.Update(watch);
                _context.SaveChanges();
                TempData["SuccessUpdate"] = "Cập nhật thành công!";
                return RedirectToAction("Watch","Home");
            }
            return View(watch);
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            var watch = _context.tbl_Watch.Find(id);
            if (watch != null) {
                _context.tbl_Watch.Remove(watch);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}