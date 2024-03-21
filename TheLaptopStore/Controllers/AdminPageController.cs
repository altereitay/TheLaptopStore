using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLaptopStore.Data;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            return View("addProduct",  new Laptop());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addProduct(IFormFile Picture) {

            Laptop l = new Laptop();
            l.Ram = Convert.ToInt32(Request.Form["Ram"]);
            l.SSD = Convert.ToInt32(Request.Form["SSD"]);
            l.CPU = Request.Form["CPU"];
            l.ScreenSize = Convert.ToDouble(Request.Form["ScreenSize"]);
            l.GPU = Request.Form["GPU"];
            l.Price = Convert.ToInt32(Request.Form["Price"]);
            l.Maker = Request.Form["Maker"];
            l.Color = Request.Form["Color"];
            l.Quantity = Convert.ToInt32(HttpContext.Request.Form["Quantity"]);
            l.Description = Request.Form["Description"];
            l.IsOnSale = true;
            l.SalePrecentage = Convert.ToInt32(Request.Form["SalePrecentage"]);
            l.PopularityIndex = 1;
            l.Category = Request.Form["Category"];
            l.ReleaseDate = Request.Form["ReleaseDate"];
            l.Model = Request.Form["Model"];

            Laptop l1 = _db.Laptops.Find(Request.Form["Model"]);
            if (l1 != null) {
                ModelState.AddModelError("Model", "Model already exists. Please choose a different one.");
                return View("addProduct", l);
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

                if (Picture.ContentType.StartsWith("image/"))
                    {

                    string webRootPath = webHostEnvironment.WebRootPath;
                    string photosFolderPath = Path.Combine(webRootPath, "photos");
                    string[] photoFiles = Directory.GetFiles(photosFolderPath);


                    bool isDuplicatePicture = _db.Laptops.Any(l => l.Picture == Picture.FileName);
                    if (isDuplicatePicture) {
                        ModelState.AddModelError("Picture", "This picture file name is already associated with another product.");
                        return View("addProduct", l);
                    }
                    else if (photoFiles.Any(filePath => Path.GetFileName(filePath) == Picture.FileName))
                    {
                        laptop.Picture = Picture.FileName;
                    }
                    else
                    {
                        laptop.Picture = Picture.FileName;
                        string path = Path.Combine(webHostEnvironment.WebRootPath, $"photos\\{laptop.Picture}");
                        using (var stream = System.IO.File.Create(path))
                        {
                            await Picture.CopyToAsync(stream);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("Picture", "This picture file must be image type.");
                    return View("addProduct", l);
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
                return View("addProduct", l);
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

        public async Task<IActionResult> edit(string? model, IFormFile Picture) {

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
            


          
              
                if (Picture != null)
              {
                if (Picture.ContentType.StartsWith("image/"))
                {
                    string webRootPath = webHostEnvironment.WebRootPath;
                    string photosFolderPath = Path.Combine(webRootPath, "photos");
                    string[] photoFiles = Directory.GetFiles(photosFolderPath);

                    for (int i = 0; i < photoFiles.Length; i++)
                    {
                        photoFiles[i] = Path.GetFileName(photoFiles[i]);
                    }

                    bool isDuplicatePicture = _db.Laptops.Any(l => l.Picture == Picture.FileName);
                    if(laptop.Picture==Picture.FileName)
                    {
                        laptop.Picture = Picture.FileName;
                    }
                    else if (isDuplicatePicture)
                    {
                        string existPath = Path.Combine(webHostEnvironment.WebRootPath, $"photos\\{laptop.Picture}");
                        laptop.Picture = Picture.FileName;
                        using (var stream = System.IO.File.OpenWrite(existPath))
                        {
                            await Picture.CopyToAsync(stream);
                        }
                    }
                    else if (photoFiles.Any(filePath => Path.GetFileName(filePath) == Picture.FileName))
                    {
                        laptop.Picture = Picture.FileName;
                    }
                    else
                    {
                        laptop.Picture = Picture.FileName;
                        string path = Path.Combine(webHostEnvironment.WebRootPath, $"photos\\{laptop.Picture}");
                        using (var stream = System.IO.File.Create(path))
                        {
                            await Picture.CopyToAsync(stream);
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("Picture", "This picture file must be image type.");
                    return View("editProduct", laptop);
                }
            }
         
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
