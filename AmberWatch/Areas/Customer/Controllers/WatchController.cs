using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Areas.Customer.Models;
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

        [HttpGet("Watch/Buy/{id}")]
        public IActionResult Buy(int id){
            var watch = _context.tbl_Watch.Find(id);
            if(watch == null){
                return NotFound();
            }
            return View(watch);
        }

        [HttpGet("Watch/CartIndex")]
        public IActionResult CartIndex(){
             var model = new HomeModel{
                Cart = _context.tbl_Cart.ToList(),
                Order = _context.tbl_Order.ToList()
             };
             return View(model);
        }

        [HttpGet("Watch/Cart")]
        public IActionResult Cart(){
            var cart = _context.tbl_Cart.ToList();
            return PartialView(cart);
        }
        [HttpGet("Watch/Order")]
        public IActionResult Order(){
            var order = _context.tbl_Order.ToList();
            return PartialView(order);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(int watchid)
        {
            int? userId = HttpContext.Session.GetInt32("id");
            var model = _context.tbl_Watch.FirstOrDefault(c => c.id_watch == watchid);
            Console.WriteLine("id la:" + watchid);
            if (userId == null)
            {
                 return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            // Kiểm tra dữ liệu đầu vào
            if (model == null)
            {
                
                return Json(new { success = false, message = "Không tìm thấy đồng hồ!" });
                
            }

            // Thêm xe vào danh sách giỏ hàng
            var neworder = new OrderModel
            {
                id_orderwatch = model.id_watch,
                id_user = userId.Value,
                model  = model.model,
                brand = model.brand,
                name = model.name,
                collection = model.collection,
                insurance = model.insurance,
                dialcolor = model.dialcolor,
                wirecolor = model.wirecolor,
                shellcolor = model.shellcolor,
                waterresistant = model.waterresistant,
                dialtype = model.dialtype,
                wiretype = model.wiretype,
                grasstype = model.grasstype,
                machinetype = model.machinetype,
                shellmaterial = model.shellmaterial,
                sex = model.sex,
                dialsize = model.dialsize,
                dialthickness = model.dialthickness,
                img =model.img,
                price = model.price,
                description =model.description
            };
            _context.tbl_Order.Add(neworder);
            await _context.SaveChangesAsync();
            
            return Json(new { success = true, message = "Đã thêm vào giỏ hàng!" });
            
        }

        [HttpPost]
        public async Task<ActionResult> AddCart(int watchid)
        {
            int? userId = HttpContext.Session.GetInt32("id");
            var model = _context.tbl_Watch.FirstOrDefault(c => c.id_watch == watchid);
            Console.WriteLine("id la:" + watchid);
            if (userId == null)
            {
                 return Json(new { success = false, message = "Vui lòng đăng nhập!" });
            }

            // Kiểm tra dữ liệu đầu vào
            if (model == null)
            {
                
                return Json(new { success = false, message = "Không tìm thấy đồng hồ!" });
                
            }

            // Kiểm tra nếu xe đã được thêm vào danh sách giỏ hàng
            var existingCart = _context.tbl_Cart.FirstOrDefault(c => c.id_user == userId && c.id_watchcart == model.id_watch);

            if (existingCart != null)
            {
                return Json(new { success = false, message = "Đồng hồ đã có trong giỏ hàng." });
            }

            // Thêm xe vào danh sách giỏ hàng
            var newCart = new CartModel
            {
                id_watchcart = model.id_watch,
                id_user = userId.Value,
                model  = model.model,
                brand = model.brand,
                name = model.name,
                collection = model.collection,
                insurance = model.insurance,
                dialcolor = model.dialcolor,
                wirecolor = model.wirecolor,
                shellcolor = model.shellcolor,
                waterresistant = model.waterresistant,
                dialtype = model.dialtype,
                wiretype = model.wiretype,
                grasstype = model.grasstype,
                machinetype = model.machinetype,
                shellmaterial = model.shellmaterial,
                sex = model.sex,
                dialsize = model.dialsize,
                dialthickness = model.dialthickness,
                img =model.img,
                price = model.price,
                description =model.description,
                quantity = 1
            };
            _context.tbl_Cart.Add(newCart);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Đã thêm vào giỏ hàng!" });
        }
    }
}