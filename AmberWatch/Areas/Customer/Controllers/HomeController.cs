using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Areas.Customer.Models;
using AmberWatch.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string query)
        {
            var watch = await _context.tbl_Watch.ToListAsync();
            if (!string.IsNullOrEmpty(query))
            {
                watch = watch
                    .Where(c => c.model.ToLower().Contains(query.ToLower()) || c.brand.ToLower().Contains(query.ToLower()))
                    .ToList();
            }
            var model = new HomeModel
            {
                watchModels = watch
            };
            ViewBag.key = query;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int orderId, int quantity)
        {
            var order = await _context.tbl_Cart.FindAsync(orderId);
            if (order == null)
            {
                return Json(new { success = false, message = "Không tìm thấy đơn hàng!" });
            }

            if (quantity < 1)
            {
                return Json(new { success = false, message = "Số lượng không hợp lệ!" });
            }

            order.quantity = quantity;  // ✅ Cập nhật số lượng
            _context.tbl_Cart.Update(order);
            await _context.SaveChangesAsync();

            decimal totalPrice = (decimal)(order.price * quantity); // ✅ Tính lại tổng giá

            return Json(new { success = true, newTotalPrice = totalPrice });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCart(int orderId)
        {
            var order = await _context.tbl_Cart.FindAsync(orderId);
            if (order == null)
            {
                return Json(new { success = false, message = "Không tìm thấy đơn hàng!" });
            }

            _context.tbl_Cart.Remove(order);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Sản phẩm đã bị xóa khỏi giỏ hàng!" });
        }

    }
}