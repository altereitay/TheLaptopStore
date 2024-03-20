using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLaptopStore.Data;



namespace TheLaptopStore.Controllers {
    public class AdminPage : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment webHostEnvironment;
        public AdminPage(ILogger<HomeController> logger, ApplicationDbContext db, IWebHostEnvironment _webHostEnvironment) {
            _logger = logger;
            _db = db;
            webHostEnvironment = _webHostEnvironment;
        }


        public IActionResult Managment() {
            List<Laptop> laptops = _db.Laptops.ToList();
            return View("AdminPage", laptops);
        }



        public IActionResult Delete(string? model) {
            var obj = _db.Laptops.Find(model);

            if (obj == null) {
                return NotFound();
            }

            _db.Laptops.Remove(obj);
            _db.SaveChanges();
            List<Laptop> laptops = _db.Laptops.ToList();
            return View("deleteProduct", laptops);
        }

        public IActionResult deleteProduct() {
            List<Laptop> laptops = _db.Laptops.ToList();
            return View("deleteProduct", laptops);
        }


        public IActionResult Add() {
            return View("addProduct");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task <IActionResult>  addProduct(IFormFile Picture) {
            
            
            Laptop l1 = _db.Laptops.Find(Request.Form["Model"]);
            if (l1 != null) {
                ModelState.AddModelError("Model", "Model already exists. Please choose a different one.");
                return View("addProduct");
            }
            if (ModelState.IsValid) {
                
                Laptop laptop = new Laptop();
                laptop.Ram = Convert.ToInt32(Request.Form["Ram"]);
                laptop.SSD = Convert.ToInt32(Request.Form["SSD"]);
                laptop.CPU = Request.Form["CPU"];
                laptop.ScreenSize = Convert.ToDouble(Request.Form["ScreenSize"]);
                laptop.GPU = Request.Form["GPU"];
                laptop.Price = Convert.ToInt32(Request.Form["Price"]);
                laptop.Maker = Request.Form["Maker"];
                laptop.Color = Request.Form["Color"];
                laptop.Quantity = Convert.ToInt32(HttpContext.Request.Form["Quantity"]);
                laptop.Description = Request.Form["Description"];
                laptop.Picture= Picture.FileName;
                string path = Path.Combine(webHostEnvironment.WebRootPath, $"photos\\{Picture.FileName}");
                using (var stream = System.IO.File.Create(path))
                {
                    await Picture.CopyToAsync(stream);
                }
                laptop.IsOnSale = true;
                laptop.SalePrecentage = Convert.ToInt32(Request.Form["SalePrecentage"]);
                laptop.PopularityIndex = 1;
                laptop.Category = Request.Form["Category"];
                laptop.ReleaseDate = Request.Form["ReleaseDate"];
                laptop.Model = Request.Form["Model"];
                _db.Laptops.Add(laptop);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            } else {
                return View("addProduct");
            }

        }
        public IActionResult ShowdeleteUser() {
            List<ApplicationUser> users = _db.Users.ToList();
            return View("deleteUser", users);
        }
        public IActionResult deleteUser(string Id) {
            var obj = _db.Users.Find(Id);

            if (obj == null) {
                return NotFound();
            }

            _db.Users.Remove(obj);
            _db.SaveChanges();
            List<ApplicationUser> users = _db.Users.ToList();
            return View("deleteUser", users);
        }
        public IActionResult showAddAdmin() {

            return View("addAdmin");
        }

        public IActionResult showEditProduct() {
            List<Laptop> laptops = _db.Laptops.ToList();
            return View("showEditProduct", laptops);
        }

        public IActionResult editProduct(string model) {
            var laptop = _db.Laptops.Find(model);
            if (laptop == null) {
                return NotFound();
            }
            return View("editProduct", laptop);
        }

        public async Task< IActionResult> edit(string? model,IFormFile Picture) {
         
            Laptop laptop = _db.Laptops.Find(model);
            laptop.Ram = Convert.ToInt32(Request.Form["Ram"]);
            laptop.SSD = Convert.ToInt32(Request.Form["SSD"]);
            laptop.CPU = Request.Form["CPU"];
            laptop.ScreenSize = Convert.ToDouble(Request.Form["ScreenSize"]);
            laptop.GPU = Request.Form["GPU"];
            laptop.Price = Convert.ToInt32(Request.Form["Price"]);
            laptop.Maker = Request.Form["Maker"];
            laptop.Color = Request.Form["Color"];
            laptop.Quantity = Convert.ToInt32(HttpContext.Request.Form["Quantity"]);
            laptop.Description = Request.Form["Description"];
            laptop.IsOnSale = Request.Form["IsOnSale"].Count > 0 ? true : false;
            laptop.SalePrecentage = Convert.ToInt32(Request.Form["SalePrecentage"]);
            laptop.PopularityIndex = Convert.ToInt32(HttpContext.Request.Form["PopularityIndex"]);
            laptop.Category = Request.Form["Category"];
            laptop.ReleaseDate = Request.Form["ReleaseDate"];
            laptop.Model = Request.Form["Model"];
            laptop.Picture = Picture.FileName;
            string path = Path.Combine(webHostEnvironment.WebRootPath, $"photos\\{laptop.Picture}");
            using (var stream = System.IO.File.OpenWrite(path))
            {
                await Picture.CopyToAsync(stream);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
